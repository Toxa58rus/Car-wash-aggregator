using CarWashAggregator.CarWashes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.CarWashes.Infra
{
    public class CarWashConfig : IEntityTypeConfiguration<CarWash>
    {
        public void Configure(EntityTypeBuilder<CarWash> builder)
        {
            builder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);


            builder.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

            builder.Property<double>("AVG_Rating")
                    .HasColumnType("double precision");

            builder.Property<string>("Address")
                    .HasColumnType("text");

            builder.Property<string[]>("CarCategories")
                    .HasColumnType("text[]");

            builder.Property<string>("Description")
                    .HasColumnType("text");

            builder.Property<byte[]>("Image")
                    .HasColumnType("bytea");

            builder.Property<string>("Name")
                    .HasColumnType("text");

            builder.Property<double>("Price")
                    .HasColumnType("double precision");

            builder.Property<Guid>("UserId")
                    .HasColumnType("uuid");

            builder.HasKey("Id");

            builder.ToTable("CarWashes");
        }
    }
}
