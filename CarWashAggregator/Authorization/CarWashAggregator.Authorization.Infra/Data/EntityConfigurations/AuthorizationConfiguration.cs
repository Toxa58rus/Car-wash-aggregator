using CarWashAggregator.Authorization.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarWashAggregator.Authorization.Infra.Data.EntityConfigurations
{
    public class AuthorizationConfiguration : IEntityTypeConfiguration<AuthorizationData>
    {
        public void Configure(EntityTypeBuilder<AuthorizationData> builder)
        {
            builder.ToTable("AuthorizationData");

            builder.HasIndex(x => x.UserLogin)
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(e => e.UserLogin)
                .HasColumnName("user_login")
                .IsRequired();

            builder.Property(e => e.HashPassword)
                .HasColumnName("hash_password")
                .IsRequired();

            builder.Property(e => e.RefreshToken)
                .HasColumnName("refresh_token")
                .IsRequired();
        }
    }
}