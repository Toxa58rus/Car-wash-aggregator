using CarWashAggregator.User.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.interfaces
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
