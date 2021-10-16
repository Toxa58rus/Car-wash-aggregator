using CarWashAggregator.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.User.infa.Data.EntityConfigurations
{
    class RoleConfigruation:IEntityTypeConfiguration<Role>
    {
       
       
            public void Configure(EntityTypeBuilder<Role> builder)
            {

                builder
                     .HasAnnotation("Relational:MaxIdentifierLength", 63)
                     .HasAnnotation("ProductVersion", "5.0.10")
                     .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);


                builder.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                builder.Property<string>("NameofRole")
                        .HasColumnType("text");


                builder.HasKey("Id");

                builder.ToTable("Roles");

            }
        
    }
}
