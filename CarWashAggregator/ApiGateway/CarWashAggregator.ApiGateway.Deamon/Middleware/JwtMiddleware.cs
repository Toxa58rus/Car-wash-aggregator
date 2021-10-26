using CarWashAggregator.ApiGateway.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.Authorization;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
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

        public async Task InvokeAsync(HttpContext context, IAuthService authorizationService, IUserService userService)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ");
            var token = authHeader?.LastOrDefault();
            var tokenType = authHeader?.FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrWhiteSpace(tokenType))
            {
                switch (tokenType)
                {
                    case "JwtAccessToken":

                        if (await HandleAccessTokenAsync(context, authorizationService, userService, token))
                        {
                            await _next(context);
                        }
                        return;
                    case "JwtRefreshToken":
                        //TODO Redirect to /refreshToken endpoint instead
                        await HandleRefreshTokenAsync(context, authorizationService, userService, token);
                        return;
                }
            }
            await _next(context);
        }

        private static async Task HandleRefreshTokenAsync(HttpContext context, IAuthService authorizationService, IUserService userService, string token)
        {
            var responseRefresh = await authorizationService.RefreshAccessTokenAsync(token);
            switch (responseRefresh.AuthFailure)
            {
                case AuthFailure.None:
                    var user = await userService.GetUserByAuthId(responseRefresh.UserId);
                    if (user is null)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json; charset=utf-8";
                        await context.Response.WriteAsync("{\"message\" : \"refresh_token_not_valid\"}");
                        return;
                    }
                    //TODO user.Email = 
                    var result = new AuthResult()
                    {
                        AccessToken = responseRefresh.AccessToken,
                        RefreshToken = responseRefresh.RefreshToken,
                        User = user
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

        private static async Task<bool> HandleAccessTokenAsync(HttpContext context, IAuthService authorizationService, IUserService userService, string token)
        {
            var responseValidate = await authorizationService.ValidateAccessTokenAsync(token);
            switch (responseValidate.ValidationFailure)
            {
                case ValidationFailure.None:
                    var authId = responseValidate.AuthId;
                    context.Items["AuthId"] = authId;
                    //TODO Authorize middleware
                    var user = await userService.GetUserByAuthId(authId);
                    if (user is null)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json; charset=utf-8";
                        await context.Response.WriteAsync("{\"message\" : \"access_token_not_valid\"}");
                        return false;
                    }
                    context.Items["Role"] = user.Role;
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
