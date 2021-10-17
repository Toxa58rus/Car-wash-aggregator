using CarWashAggregator.Orders.Business.interfaces;
using CarWashAggregator.User.Domain.Contracts;
using CarWashAggregator.User.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarWashAggregator.Orders.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _dbRepository;

        public UserService(IUserRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public IEnumerable<UserInfo> GetUsers()
        {
            return _dbRepository.Get().AsEnumerable();
        }
    }
}
