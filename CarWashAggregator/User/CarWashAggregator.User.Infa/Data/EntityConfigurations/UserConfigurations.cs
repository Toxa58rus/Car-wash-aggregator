using CarWashAggregator.User.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.Infa.Data.EntityConfigurations
{
    class UserConfigurations: IEntityTypeConfiguration<UserInfo>
    {

        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {

            builder
                 .HasAnnotation("Relational:MaxIdentifierLength", 63)
                 .HasAnnotation("ProductVersion", "5.0.10")
                 .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);


            builder.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

            builder.Property<Guid>("AuthId")
                    .HasColumnType("uuid");

            builder.Property<int>("Role")
                    .HasColumnType("integer");

            builder.Property<string>("FirstName")
                    .HasColumnType("text");

            builder.Property<string>("LastName")
                    .HasColumnType("text");

            builder.Property<string>("Phone")
                    .HasColumnType("text");
            
            builder.Property<string>("City")
                    .HasColumnType("text");

            builder.HasKey("Id");

            builder.ToTable("UserInfos");

        }
    }
}
