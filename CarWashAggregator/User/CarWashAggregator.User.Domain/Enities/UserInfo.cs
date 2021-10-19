using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.Domain.Enities
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Guid CarId { get; set; }
        public Guid RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }
        public ICollection<Role> Role { get; set; }
        public ICollection<Car> Car { get; set; }
    }
}
