using CarWashAggregator.Files.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Files.Infra
{
    public class FileConfig : IEntityTypeConfiguration<FileModel>
    {
        public void Configure(EntityTypeBuilder<FileModel> builder)
        {
            builder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            builder.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

            builder.Property<byte[]>("Content")
                .HasColumnType("bytea");

            builder.Property<int>("ContentLength")
                .HasColumnType("integer");

            builder.Property<string>("ContentType")
                .HasColumnType("text");

            builder.Property<string>("FileName")
                .HasMaxLength(255)
                .HasColumnType("character varying(255)");

            builder.HasKey("Id");

            builder.ToTable("Files");
        }
    }
}
