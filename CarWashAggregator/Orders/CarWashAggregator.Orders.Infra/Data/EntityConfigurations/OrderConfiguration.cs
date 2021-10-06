using CarWashAggregator.Orders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarWashAggregator.Orders.Infra.Data.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.СarWashId)
                .HasColumnName("carwash_Id")
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnName("wash_price")
                .IsRequired();

            builder.Property(e => e.DateReservation)
                .HasColumnName("reservation_at")
                                .IsRequired();


            builder.HasOne(d => d.СarWashStatus)
                .WithOne(p => p.Order)
                .HasForeignKey<Status>(d => d.OrderId);

        }
    }
}
