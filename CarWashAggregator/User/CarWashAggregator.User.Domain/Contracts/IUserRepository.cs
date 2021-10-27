using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.User.Domain.Enities;

namespace CarWashAggregator.User.Domain.Contracts
{
    public interface IUserRepository
    {
        IQueryable<UserInfo> Get();
        Task<UserInfo> GetUserByIdAsync(Guid id);
        Task<UserInfo> GetUserByAuthIdAsync(Guid id);
        Task<Guid> Add(UserInfo newEntity);
        Task Remove(UserInfo entity);
        Task DeleteUserByIdAsync(Guid id);
        Task Update(UserInfo entity);
        Task SaveChangesAsync();
    }
}
