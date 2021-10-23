using CarWashAggregator.Notifications.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Notifications.Infra
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            builder.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid");

            builder.Property<string>("Body")
                .HasColumnType("text");

            builder.Property<bool>("IsRead")
                .HasColumnType("boolean");

            builder.Property<Guid>("UserId")
                .HasColumnType("uuid");

            builder.HasKey("Id");

            builder.ToTable("Notifications");
        }
    }
}
