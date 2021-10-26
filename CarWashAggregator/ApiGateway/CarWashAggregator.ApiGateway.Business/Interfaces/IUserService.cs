using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using System;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticatedUserModel> GetUserByAuthId(Guid id);
    }
}