using CarWashAggregator.User.Domain.Contracts;
using CarWashAggregator.User.Domain.Enities;
using CarWashAggregator.User.Infa.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.User.Infa.Repository
{
    public class UserReposirory: IUserRepository
    {
        private readonly UserContext _context;
        public UserReposirory(UserContext context)
        {
            _context = context;
        }
        public async Task Add<UserInfo>(UserInfo newEntity)
        {
            await Task.Run(() => _context.AddAsync( newEntity));
        }

        public IQueryable<UserInfo> Get()
        {
            return _context.UserInfos;
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
            await Task.Run(() => _context.SaveChangesAsync());
        }
    }
}
