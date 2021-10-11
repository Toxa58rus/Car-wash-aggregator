using System;

namespace CarWashAggregator.Notification.Domain
{
    public class BaseClass : INotification
    {
        public DateTime date { get; set; } = DateTime.UtcNow;
        public string text{ get; set; }
        public string theme { get; set; }
        public DateTime GetDateTime()
        { 
            return date;
        }
        public string GetText(string text)
        {
            return text;
        }
        public string GetTheme(string theme)
        {
            return theme;
        }
    }
}