using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Notifications.Domain.Interfaces
{
    public interface INotificationService
    {
        Task<Guid> CreateNotificationAsync(Notification notification);
        Task<Notification> GetNotificationByIdAsync(Guid id);
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(Notification notification);
        Task DeleteNotificationByIdAsync(Guid id);
    }
}
