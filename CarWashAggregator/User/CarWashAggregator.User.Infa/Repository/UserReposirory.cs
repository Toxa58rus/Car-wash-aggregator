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

        public async Task<UserInfo> GetUserByIdAsync(Guid id)
        {
            return await _context.UserInfos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Guid> Add(UserInfo newEntity)
        {
            await _context.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return newEntity.Id;
        }

        public IQueryable<UserInfo> Get()
        {
            return _context.UserInfos;
        }

        public async Task Remove(UserInfo entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserInfo entity)
        {
            _context.Attach(entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Task.Run(() => _context.SaveChangesAsync());
        }

        public async Task DeleteUserByIdAsync(Guid id)
        {
            _context.Remove(await _context.UserInfos.Where(x => x.Id == id).FirstOrDefaultAsync());
            await _context.SaveChangesAsync();
        }
    }
}
