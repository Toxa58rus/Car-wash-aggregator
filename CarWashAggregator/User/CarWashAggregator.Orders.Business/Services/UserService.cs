using CarWashAggregator.User.Domain.Contracts;
using CarWashAggregator.User.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashAggregator.User.Domain.interfaces;

namespace CarWashAggregator.Orders.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _dbRepository;

        public UserService(IUserRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<Guid> CreateUserAsync(UserInfo user)
        {
            return await _dbRepository.Add(user);
        }

        public async Task DeleteUserByIdAsync(Guid id)
        {
            await _dbRepository.DeleteUserByIdAsync(id);
        }

        public async Task<UserInfo> GetUserByIdAsync(Guid id)
        {
            return await _dbRepository.GetUserByIdAsync(id);
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            return _dbRepository.Get().AsEnumerable();
        }

        public async Task UpdateUserAsync(UserInfo user)
        {
            await _dbRepository.Update(user);
        }
    }
}
