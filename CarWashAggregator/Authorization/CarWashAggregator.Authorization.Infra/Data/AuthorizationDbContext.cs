using CarWashAggregator.Authorization.Domain.Entities;
using CarWashAggregator.Authorization.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CarWashAggregator.Authorization.Infra.Data
{
    public class AuthorizationDbContext : DbContext
    {
        public DbSet<AuthorizationData> AuthorizationDataDbSet { get; set; }
        public DbSet<Role> RoleDbSet { get; set; }


        public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorizationDataConfiguration())
                .ApplyConfiguration(new RoleConfiguration());
        }

    }
}