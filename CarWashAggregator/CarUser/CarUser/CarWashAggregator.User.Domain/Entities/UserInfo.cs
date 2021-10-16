using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWashAggregator.User.Domain.Entities
{
    public class UserInfo
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }
        public ICollection<Role> Role { get; set; }
        public ICollection<Car> Car { get; set; }
    }
}
