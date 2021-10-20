using CarWashAggregator.Common.Domain.Contracts;
using System.IdentityModel.Tokens.Jwt;

namespace CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response
{
    public class ResponseTokenValidationCheck : Query
    {
        public bool TokenIsValid { get; set; }
        public ValidationFailure ValidationFailure { get; set; }
        public JwtSecurityToken ValidatedToken { get; set; }
    }
}
