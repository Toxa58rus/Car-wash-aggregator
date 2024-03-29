﻿using CarWashAggregator.ApiGateway.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.Entities;

namespace CarWashAggregator.ApiGateway.Infra.Data
{
    public class ApiGatewayContext : DbContext
    {
        public DbSet<GatewayLog> GatewayLogs { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public ApiGatewayContext(DbContextOptions<ApiGatewayContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GatewayLogConfiguration());
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
