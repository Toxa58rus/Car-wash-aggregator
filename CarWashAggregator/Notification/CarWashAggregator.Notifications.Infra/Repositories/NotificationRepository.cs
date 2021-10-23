using CarWashAggregator.Notifications.Domain;
using CarWashAggregator.Notifications.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Notifications.Infra.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationContext _context;

        public NotificationRepository(NotificationContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateNotificationAsync(Notification notification)
        {
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification.Id;
        }

        public async Task DeleteNotificationAsync(Notification notification)
        {
            _context.Remove(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationByIdAsync(Guid id)
        {
            Notification notification = await _context.Notifications.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Remove(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(Guid id)
        {
            return await _context.Notifications.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            _context.Attach(notification);
            _context.Update(notification);
            await _context.SaveChangesAsync();
        }
    }
}
