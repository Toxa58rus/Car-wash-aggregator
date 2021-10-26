using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.Domain.Enities
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public Guid AuthId { get; set; }
        public int Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
