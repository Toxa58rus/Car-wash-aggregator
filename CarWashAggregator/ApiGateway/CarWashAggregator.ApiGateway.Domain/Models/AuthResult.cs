using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestsModels;

namespace CarWashAggregator.ApiGateway.Domain.Models
{
   public class AuthResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public RegisteredUserModel User { get; set; }
    }
}
