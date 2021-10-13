using CarWashAggregator.Files.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Files.Infra
{
    public class ApplicationContext : DbContext
    {
        public DbSet<FileModel> Files { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileConfig());
        }
    }
}
