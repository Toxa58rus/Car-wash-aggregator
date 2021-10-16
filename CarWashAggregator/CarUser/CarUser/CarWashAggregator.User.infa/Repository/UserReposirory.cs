using CarWashAggregator.User.Domain.Contracts;
using CarWashAggregator.User.Domain.Entities;
using CarWashAggregator.User.infa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.User.infa.Repository
{
    class UserReposirory : IUserRepository
    {
        private readonly UserContext _context;
        public UserReposirory(UserContext context)
        {
            _context = context;
        }
        public async Task Add<UserInfo>(UserInfo newEntity)
        {
            await Task.Run(()=>_context.AddRangeAsync(newEntity));
        }

        public IQueryable<UserInfo> Get<UserInfo>()
        {
            return (IQueryable<UserInfo>)_context.UserInfos;
        }

        public async Task Remove<UserInfo>(UserInfo entity) 
        {
            await Task.Run(() => _context.RemoveRange(entity));
        }

        public async Task Update<UserInfo>(UserInfo entity) 
        {
            await Task.Run(() => _context.UpdateRange(entity));
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

     
    }
}
