using System;

namespace CarWashAggregator.Notification.Domain
{
    public interface INotification
    {
        DateTime date { get; set; }
        string text { get; set; }
        string theme { get; set; }
    }
}
