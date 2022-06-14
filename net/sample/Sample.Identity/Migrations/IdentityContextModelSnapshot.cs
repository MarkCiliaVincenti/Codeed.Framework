﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sample.Identity;

#nullable disable

namespace Sample.Identity.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Codeed.Framework.Identity.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("EMAIL");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("IMAGE_URL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("NAME");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("UID");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .HasDatabaseName("USER_UID_I");

                    b.ToTable("USERS", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
