using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWashAggregator.User.Domain.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string NameofRole { get; set; }
        public UserInfo User { get; set; }
    }
}
