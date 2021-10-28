using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using System;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticatedUserModel> GetUserById(Guid id);
        Task<AuthenticatedUserModel> GetUserByAuthId(Guid id);
        Task<bool> ChangeUserProfile(UserProfile profile);
    }
}