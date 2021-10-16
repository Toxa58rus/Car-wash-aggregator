using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWashAggregator.User.Domain.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }
        public UserInfo User { get; set; }
    }
}
