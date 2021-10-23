using System;
using System.ComponentModel.DataAnnotations;

namespace CarWashAggregator.Notifications.Domain
{
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsRead { get; set; }
        public string Body { get; set; }
    }
}
