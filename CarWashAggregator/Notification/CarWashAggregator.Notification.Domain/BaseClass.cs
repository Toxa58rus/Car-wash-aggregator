using System;

namespace CarWashAggregator.Notification.Domain
{
    class BaseClass : INotification
    {
        public DateTime date { get; set; } = DateTime.UtcNow;
        public string notificate { get; set; }
    }
}