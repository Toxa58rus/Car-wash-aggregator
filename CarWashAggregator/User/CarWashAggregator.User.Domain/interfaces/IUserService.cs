using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashAggregator.User.Domain.Enities;

namespace CarWashAggregator.User.Domain.interfaces
{
    public interface IUserService
    {
        IEnumerable<UserInfo> GetUsers();
        Task<UserInfo> GetUserByIdAsync(Guid id);
        Task<Guid> CreateUserAsync(UserInfo user);
        Task UpdateUserAsync(UserInfo user);
        Task DeleteUserByIdAsync(Guid id);
    }
}
