using CarWashAggregator.Notifications.Domain;
using CarWashAggregator.Notifications.Domain.Interfaces;
using CarWashAggregator.Notifications.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Notifications.BL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Guid> CreateNotificationAsync(Notification notification)
        {
            return await _notificationRepository.CreateNotificationAsync(notification);
        }

        public async Task DeleteNotificationAsync(Notification notification)
        {
            await _notificationRepository.DeleteNotificationAsync(notification);
        }

        public async Task DeleteNotificationByIdAsync(Guid id)
        {
            await _notificationRepository.DeleteNotificationByIdAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await _notificationRepository.GetAllNotifications();
        }

        public async Task<Notification> GetNotificationByIdAsync(Guid id)
        {
            return await _notificationRepository.GetNotificationByIdAsync(id);
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _notificationRepository.UpdateNotificationAsync(notification);
        }
    }
}
