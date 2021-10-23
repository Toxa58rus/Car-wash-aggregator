using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Notifications.Domain.Repositories
{
    public interface INotificationRepository
    {
        Task<Guid> CreateNotificationAsync(Notification notification);
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task<Notification> GetNotificationByIdAsync(Guid id);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(Notification notification);
        Task DeleteNotificationByIdAsync(Guid id);
    }
}
