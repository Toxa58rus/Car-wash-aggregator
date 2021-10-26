using CarWashAggregator.ApiGateway.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarWashAggregator.ApiGateway.Infra.Data.EntityConfigurations
{
    public class GatewayLogConfiguration : IEntityTypeConfiguration<GatewayLog>
    {
        public void Configure(EntityTypeBuilder<GatewayLog> builder)
        {
            builder.ToTable("GatewayLogs");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(e => e.Message)
                .HasColumnName("logged_message")
                .IsRequired();
        }
    }
}
