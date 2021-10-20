using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.Domain.Enities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string NameofRole { get; set; }
        public UserInfo User { get; set; }
    }
}
