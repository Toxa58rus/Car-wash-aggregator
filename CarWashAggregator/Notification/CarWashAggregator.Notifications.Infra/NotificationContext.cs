using CarWashAggregator.Notifications.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarWashAggregator.Notifications.Infra
{
    public class NotificationContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }

        public NotificationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationConfig());
        }
    }
}
