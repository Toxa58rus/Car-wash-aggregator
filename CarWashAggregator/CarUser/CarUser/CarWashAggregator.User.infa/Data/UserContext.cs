using CarWashAggregator.User.Domain.Entities;
using CarWashAggregator.User.infa.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.infa.Data
{
    public class UserContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigruation())
                .ApplyConfiguration(new CarConfigruation())
                .ApplyConfiguration(new RoleConfigruation());
        }
    }
}
