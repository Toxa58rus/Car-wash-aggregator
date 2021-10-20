using CarWashAggregator.User.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.Infa.Data.EntityConfigurations
{
    class CarConfigurations: IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {

            builder
                 .HasAnnotation("Relational:MaxIdentifierLength", 63)
                 .HasAnnotation("ProductVersion", "5.0.10")
                 .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);


            builder.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

            builder.Property<string>("Category")
                    .HasColumnType("text");



            builder.HasKey("Id");

            builder.ToTable("Cars");

        }
    }
}
