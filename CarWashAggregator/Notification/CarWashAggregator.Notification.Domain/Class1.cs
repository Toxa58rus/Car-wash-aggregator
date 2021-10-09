using System;

namespace CarWashAggregator.Notification.Domain
{
    public interface INotification
    {
        DateTime date { get; set; }
        string notificate { get; set; }
    }
}
