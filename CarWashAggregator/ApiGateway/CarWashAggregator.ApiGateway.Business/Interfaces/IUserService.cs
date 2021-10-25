using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using System;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticatedUserModel> GetUserById(Guid id);
        Task<int?> GetUserRoleByUserId(Guid id);
    }
}