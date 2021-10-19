using System.IdentityModel.Tokens.Jwt;

namespace CarWashAggregator.Authorization.Business.JwtAuth.Models
{
    public class JwtValidationResult
    {
        public bool TokenIsValid { get; set; }
        public JwtSecurityToken ValidatedToken { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
    }
}
