using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Authorization.Business.JwtAuth.Models;
using CarWashAggregator.Authorization.Domain.Contracts;
using CarWashAggregator.Authorization.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Business.JwtAuth.Implementation
{


    public class AuthorizationManager : IAuthorizationManager
    {
        private const string ClaimsRoleType = "user_role";
        private const string ClaimsPasswordType = "user_password";
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly byte[] _secret;

        public AuthorizationManager(JwtTokenConfig tokenConfig, IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
            _jwtTokenConfig = tokenConfig;
            _secret = Encoding.ASCII.GetBytes(_jwtTokenConfig.Secret);
        }

        public async Task<JwtAuthResult> RegisterAsync(string login, string password, string role)
        {
            var hashPassword = GetHashPassword(password);
            var existUser = _authorizationRepository.Get<AuthorizationData>()
                 .FirstOrDefault(x => x.UserLogin == login && x.HashPassword == hashPassword);
            if (existUser != null)
            {
                return new JwtAuthResult()
                {
                    Error = "User already exist"
                };
            }

            //TODO UserCreatedEvent -> UserService
            var refreshToken = GenerateRefreshToken();
            var newUserId = await _authorizationRepository.Add(new AuthorizationData()
            {
                UserLogin = login,
                HashPassword = hashPassword,
                RefreshToken = refreshToken,
                ExpireAt = DateTime.UtcNow.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration)
            });
            await _authorizationRepository.SaveChangesAsync();

            var accessToken = await GenerateAccessToken(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(ClaimsRoleType, role),
                new Claim(ClaimsPasswordType, hashPassword)
            });

            return new JwtAuthResult()
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<JwtAuthResult> LoginAsync(string login, string password, string role)
        {
            var hashPassword = GetHashPassword(password);
            var existUser = _authorizationRepository.Get<AuthorizationData>()
                .FirstOrDefault(x => x.UserLogin == login && x.HashPassword == hashPassword);

            if (existUser is null)
            {
                return new JwtAuthResult()
                {
                    Error = "Login/Password is not valid"
                };
            }

            var refreshToken = GenerateRefreshToken();
            existUser.RefreshToken = refreshToken;
            existUser.ExpireAt = DateTime.UtcNow.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration);
            await _authorizationRepository.Update(existUser);
            await _authorizationRepository.SaveChangesAsync();

            var accessToken = await GenerateAccessToken(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),
                new Claim(ClaimsRoleType, role),
                new Claim(ClaimsPasswordType, hashPassword)
            });

            return new JwtAuthResult()
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        public bool ValidateJwtToken(string token)
        {
            try
            {
                new JwtSecurityTokenHandler()
                    .ValidateToken(token,
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = _jwtTokenConfig.Issuer,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(_secret),
                            ValidAudience = _jwtTokenConfig.Audience,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.FromMinutes(1)
                        },
                        out _);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<JwtAuthResult> RefreshTokenAsync(string accessToken, string refreshToken)
        {
            if (!ValidateJwtToken(accessToken))
            {
                return new JwtAuthResult()
                {
                    Error = "Invalid token"
                };
            }
            var jwtToken = DecodeJwtToken(accessToken);

            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return new JwtAuthResult()
                {
                    Error = "Invalid token"
                };
            }

            var login = GetClaim(jwtToken, JwtRegisteredClaimNames.Sub);
            var hashPassword = GetClaim(jwtToken, ClaimsPasswordType);

            AuthorizationData session;
            try
            {
                session = _authorizationRepository.Get<AuthorizationData>().Single(x => x.UserLogin == login && x.HashPassword == hashPassword);
            }
            catch (Exception ex)
            {
                return new JwtAuthResult()
                {
                    Error = ex.Message
                };
            }

            if (session.ExpireAt < DateTime.UtcNow || refreshToken != session.RefreshToken)
            {
                return new JwtAuthResult()
                {
                    Error = "RefreshToken expired"
                };
            }

            refreshToken = GenerateRefreshToken();
            session.RefreshToken = refreshToken;
            session.ExpireAt = DateTime.UtcNow.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration);
            await _authorizationRepository.Update(session);
            await _authorizationRepository.SaveChangesAsync();

            var newAccessToken = await GenerateAccessToken(jwtToken.Claims.ToArray());

            return new JwtAuthResult()
            {
                Success = true,
                AccessToken = newAccessToken,
                RefreshToken = refreshToken
            };
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
        private Task<string> GenerateAccessToken(Claim[] claims)
        {
            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtTokenConfig.Audience,
                Expires = now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
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
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private static JwtSecurityToken DecodeJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            return securityToken;
        }
        private static string GetClaim(JwtSecurityToken securityToken, string claimType)
        {
            return securityToken.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }

    }
}
