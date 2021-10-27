using CarWashAggregator.User.Domain.Enities;
using CarWashAggregator.User.Infa.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashAggregator.User.Infa.Data
{
    public class UserContext: DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
        }
    }
}
