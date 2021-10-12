using CarWashAggregator.CarWashes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.CarWashes.Infra
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CarWash> CarWashes { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarWashConfig());
        }
    }
}
