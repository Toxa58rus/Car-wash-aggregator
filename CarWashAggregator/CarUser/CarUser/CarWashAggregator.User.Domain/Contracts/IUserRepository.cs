using CarWashAggregator.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.User.Domain.Contracts
{
    public interface IUserRepository
    {
        IQueryable<UserInfo> Get<UserInfo>();
        Task Add<UserInfo>(UserInfo newEntity);
        Task Remove<UserInfo>(UserInfo entity);
        Task Update<UserInfo>(UserInfo entity);
        Task SaveChangesAsync();

    }
}
