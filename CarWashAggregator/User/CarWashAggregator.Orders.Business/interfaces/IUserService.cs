using CarWashAggregator.User.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Orders.Business.interfaces
{
    public interface IUserService
    {
        IEnumerable<UserInfo> GetUsers();
    }
}
