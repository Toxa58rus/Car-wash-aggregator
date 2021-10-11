using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Notification.Domain;

namespace CarWashAggregator.Notification.Infra
{
    public class Context : DbContext
    {
        public DbSet<BaseClass> Notification { get; set; }
        public Context(DbContextOptions<Context> options) : base (options)
        {
            Database.EnsureCreated();
        }

    }
}
