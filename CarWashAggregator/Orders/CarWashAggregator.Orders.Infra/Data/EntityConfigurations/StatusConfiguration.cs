using CarWashAggregator.Orders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarWashAggregator.Orders.Infra.Data.EntityConfigurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name_of_status")
                .IsRequired();
            
            builder.HasMany(d => d.Orders)
                .WithOne(p => p.OrderStatus)
                .HasForeignKey(d => d.StatusId);
        }
    }
}
