using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Authorization.Business.JwtAuth.Models;
using CarWashAggregator.Authorization.Domain.Contracts;
using CarWashAggregator.Authorization.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ValidationFailure = CarWashAggregator.Authorization.Business.JwtAuth.Models.ValidationFailure;

namespace CarWashAggregator.Authorization.Business.JwtAuth.Implementation
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private const string ClaimsRoleType = "user_role";
        private const string ClaimsPasswordType = "user_password";
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly byte[] _secret;
        private readonly ILogger _logger;

        public AuthorizationManager(JwtTokenConfig tokenConfig, IAuthorizationRepository authorizationRepository, ILogger<AuthorizationManager> logger)
        {
            _authorizationRepository = authorizationRepository;
            _jwtTokenConfig = tokenConfig;
            _secret = Encoding.ASCII.GetBytes(_jwtTokenConfig.Secret);
            _logger = logger;
        }

        public async Task<JwtAuthResult> RegisterAsync(string login, string password, int role)
        {
            var hashPassword = GetHashPassword(password);
            var existUser = _authorizationRepository.Get<AuthorizationData>()
                 .FirstOrDefault(x => x.UserLogin == login && x.HashPassword == hashPassword);
            if (existUser != null)
            {
                return new JwtAuthResult()
                {
                    AuthFailure = AuthFailure.UserAlreadyExist
                };
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(ClaimsRoleType, role.ToString()),
                new Claim(ClaimsPasswordType, hashPassword)
            };

            var refreshToken = await GenerateToken(claims, _jwtTokenConfig.RefreshTokenExpiration);
            var accessToken = await GenerateToken(claims, _jwtTokenConfig.AccessTokenExpiration);
            await _authorizationRepository.Add(new AuthorizationData()
            {
                UserLogin = login,
                HashPassword = hashPassword,
                RefreshToken = refreshToken,
            });
            await _authorizationRepository.SaveChangesAsync();
            _logger.LogDebug("User {Email} registered", login);

            return new JwtAuthResult()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<JwtAuthResult> LoginAsync(string login, string password, int role)
        {
            var hashPassword = GetHashPassword(password);
            var existUser = _authorizationRepository.Get<AuthorizationData>()
                .FirstOrDefault(x => x.UserLogin == login && x.HashPassword == hashPassword);

            if (existUser is null)
            {
                return new JwtAuthResult()
                {
                    AuthFailure = AuthFailure.UserDoesNotExist
                };
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(ClaimsRoleType, role.ToString()),
                new Claim(ClaimsPasswordType, hashPassword)
            };

            var refreshToken = await GenerateToken(claims, _jwtTokenConfig.RefreshTokenExpiration);
            var accessToken = await GenerateToken(claims, _jwtTokenConfig.AccessTokenExpiration);

            existUser.RefreshToken = refreshToken;
            await _authorizationRepository.Update(existUser);
            await _authorizationRepository.SaveChangesAsync();
            _logger.LogDebug("User {Email} logged in", login);

            return new JwtAuthResult()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<JwtAuthResult> RefreshAccessTokenAsync(string refreshToken)
        {
            var (jwtToken, validationFailure) = ValidateJwt(refreshToken, false, false, false);
            if (validationFailure != ValidationFailure.None)
            {
                return new JwtAuthResult()
                {
                    AuthFailure = AuthFailure.TokenNotValid
                };
            }

            var login = GetClaim(jwtToken, JwtRegisteredClaimNames.Sub);
            var hashPassword = GetClaim(jwtToken, ClaimsPasswordType);
            var role = GetClaim(jwtToken, ClaimsRoleType);

            AuthorizationData existUser;
            try
            {
                existUser = _authorizationRepository.Get<AuthorizationData>()
                    .Single(x => x.UserLogin == login);
            }
            catch (Exception ex)
            {
                _logger.LogError("Check {Email} in DataBase \n Exception Message: {Message}", login, ex.Message);
                return new JwtAuthResult()
                {
                    AuthFailure = AuthFailure.ServerError
                };
            }

            if (existUser.HashPassword != hashPassword || existUser.RefreshToken != refreshToken)
            {
                return new JwtAuthResult()
                {
                    AuthFailure = AuthFailure.TokenNotValid
                };
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(ClaimsRoleType, role),
                new Claim(ClaimsPasswordType, hashPassword)
            };

            var newRefreshToken = await GenerateToken(claims, _jwtTokenConfig.RefreshTokenExpiration);
            var newAccessToken = await GenerateToken(claims, _jwtTokenConfig.AccessTokenExpiration);

            existUser.RefreshToken = refreshToken;
            await _authorizationRepository.Update(existUser);
            await _authorizationRepository.SaveChangesAsync();

            return new JwtAuthResult()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public Task<JwtValidationResult> ValidateAccessToken(string token)
        {
            var (jwtToken, validationFailure) = ValidateJwt(token);
            var result = new JwtValidationResult
            {
                ValidationFailure = validationFailure
            };
            if (validationFailure == ValidationFailure.None)
            {
                var login = GetClaim(jwtToken, JwtRegisteredClaimNames.Sub);
                result.UserId = _authorizationRepository.Get<AuthorizationData>()
                    .SingleOrDefault(x => x.UserLogin == login)?.Id;
            }
            return Task.FromResult(result);
        }

        private (JwtSecurityToken, ValidationFailure) ValidateJwt(string token,
            bool validateLifetime = true,
            bool validateIssuer = true,
            bool validateAudience = true)
        {
            JwtSecurityToken result;
            try
            {
                new JwtSecurityTokenHandler()
                    .ValidateToken(token,
                        new TokenValidationParameters
                        {
                            ValidateIssuer = validateIssuer,
                            ValidIssuer = _jwtTokenConfig.Issuer,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(_secret),
                            ValidAudience = _jwtTokenConfig.Audience,
                            ValidateAudience = validateAudience,
                            ValidateLifetime = validateLifetime,
                        },
                        out var validatedToken);
                result = validatedToken as JwtSecurityToken;
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Failed to validate AccessToken {AccessToken} \n Message:{Message}", token,
                    ex.Message);
                if (ex is SecurityTokenExpiredException)
                {
                    return (null, ValidationFailure.InvalidLifetime);
                }
                else
                {
                    return (null, ValidationFailure.InvalidToken);
                }
            }
            return (result, ValidationFailure.None);
        }

        private static string GetHashPassword(string password)
        {
            var bytePas = Encoding.UTF8.GetBytes(password);
            var hash = SHA256.Create().ComputeHash(bytePas);
            var sBuilder = new StringBuilder();
            foreach (var b in hash)
            {
                sBuilder.Append(b.ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private Task<string> GenerateToken(IEnumerable<Claim> claims, int minutesTilExpire)
        {
            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtTokenConfig.Audience,
                Expires = now.AddMinutes(minutesTilExpire),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtTokenConfig.Issuer,
                IssuedAt = now,
                NotBefore = now,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }
        private static string GetClaim(JwtSecurityToken securityToken, string claimType)
        {
            return securityToken.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
    }
}
