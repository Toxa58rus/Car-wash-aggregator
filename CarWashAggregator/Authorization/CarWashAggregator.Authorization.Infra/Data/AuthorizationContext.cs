using CarWashAggregator.Authorization.Domain.Entities;
using CarWashAggregator.Authorization.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashAggregator.Authorization.Infra.Data
{
    public class AuthorizationContext : DbContext
    {
        public DbSet<AuthorizationData> AuthorizationDataDbSet { get; set; }

        public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorizationConfiguration());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}