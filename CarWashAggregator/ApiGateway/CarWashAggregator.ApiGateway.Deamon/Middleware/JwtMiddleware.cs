using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestsModels;
using CarWashAggregator.Common.Domain.Contracts;
using ValidationFailure = CarWashAggregator.ApiGateway.Domain.Models.Authorization.ValidationFailure;

namespace CarWashAggregator.ApiGateway.Deamon.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthService authorizationService, IEventBus bus, IMapper mapper)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ");
            var token = authHeader?.LastOrDefault();
            var tokenType = authHeader?.FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrWhiteSpace(tokenType))
            {
                switch (tokenType)
                {
                    case "JwtAccessToken":

                        if (await HandleAccessTokenAsync(context, authorizationService, bus, token))
                        {
                            await _next(context);
                        }
                        return;
                    case "JwtRefreshToken":
                        await HandleRefreshTokenAsync(context, authorizationService, bus, mapper, token);
                        return;
                }
            }
            await _next(context);
        }

        private static async Task HandleRefreshTokenAsync(HttpContext context, IAuthService authorizationService, IEventBus bus, IMapper mapper, string token)
        {
            var responseRefresh = await authorizationService.RefreshAccessTokenAsync(token);
            switch (responseRefresh.AuthFailure)
            {
                case AuthFailure.None:
                    //TODO Request User
                    var user = new UserModel();
                    var result = new AuthResult()
                    {
                        AccessToken = responseRefresh.AccessToken,
                        RefreshToken = responseRefresh.RefreshToken,
                        User = mapper.Map<RegisteredUserModel>(user)
                    };
                    var response = JsonConvert.SerializeObject(result,
                        new JsonSerializerSettings()
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        });
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync(response);
                    return;
                default:
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync("{\"message\" : \"refresh_token_not_valid\"}");
                    return;
            }
        }

        private static async Task<bool> HandleAccessTokenAsync(HttpContext context, IAuthService authorizationService, IEventBus bus, string token)
        {
            var responseValidate = await authorizationService.ValidateAccessTokenAsync(token);
            switch (responseValidate.ValidationFailure)
            {
                case ValidationFailure.None:
                    context.Items["UserId"] = responseValidate.UserId;
                    //TODO RequestRole
                    //var userRole = await bus.RequestQuery<>()
                    // context.Items["UserRole"] = userRole;
                    return true;
                case ValidationFailure.InvalidLifetime:
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync("{\"message\" : \"access_token_life_time_expired\"}");
                    return false;
                case ValidationFailure.InvalidToken:
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync("{\"message\" : \"access_token_not_valid\"}");
                    return false;
                default:
                    return false;
            }
        }
    }
}
