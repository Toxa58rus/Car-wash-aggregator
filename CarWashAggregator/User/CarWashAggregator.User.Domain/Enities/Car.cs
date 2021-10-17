using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.Domain.Enities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public UserInfo User { get; set; }
    }
}
