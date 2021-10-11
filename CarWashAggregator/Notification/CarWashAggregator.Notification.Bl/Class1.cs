using System;
using CarWashAggregator.Notification.Domain;

namespace CarWashAggregator.Notification.Bl
{
    public class Class1 : BaseClass
    {
        public void SendNotific(string text, string theme)
        {
            GetDateTime();
            GetText(text);
            GetTheme(theme);
        }
    }
}
