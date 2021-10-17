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
        Task Add<UserInfo>(UserInfo newEntity);
        Task Remove<UserInfo>(UserInfo entity);
        Task Update<UserInfo>(UserInfo entity);
        Task SaveChangesAsync();
    }
}
