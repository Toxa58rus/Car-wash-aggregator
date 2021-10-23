using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarWashAggregator.ApiGateway.Deamon.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Roles> _roles;
        public AuthorizeAttribute(IAuthService authService, params Roles[] roles)
        {
            _roles = roles ?? new Roles[] {};
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRole = (Roles)context.HttpContext.Items["UserRole"];
            
                //TODO
            if (_roles.Any() && !_roles.Contains(Roles.User))
            {
                // not logged in or role not authorized
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
