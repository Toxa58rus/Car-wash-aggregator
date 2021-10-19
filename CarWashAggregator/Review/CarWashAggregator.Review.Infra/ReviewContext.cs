using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarWashAggregator.Review.Infra
{
	public class ReviewContext : DbContext
	{
		private IConfiguration _configuration;

		public ReviewContext()
		{

		}

		public ReviewContext(DbContextOptions<ReviewContext> options, IConfiguration configuration)
			: base(options)
		{
			_configuration = configuration;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());

		}

		public virtual DbSet<Domain.Models.Entities.Review> Reviews { get; set; }
	
	}
}
