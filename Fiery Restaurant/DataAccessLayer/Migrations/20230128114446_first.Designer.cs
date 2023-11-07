﻿// <auto-generated />
using System;
using DataAccessLayer.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(SupplierDBContext))]
    [Migration("20230128114446_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Address", b =>
                {
                    b.Property<Guid>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entity.Business", b =>
                {
                    b.Property<Guid>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LicenseDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("LicenseNo")
                        .HasColumnType("bigint");

                    b.HasKey("SupplierID");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("Domain.Entity.Supplier", b =>
                {
                    b.Property<Guid>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastDateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Domain.Entity.Address", b =>
                {
                    b.HasOne("Domain.Entity.Supplier", null)
                        .WithOne("Address")
                        .HasForeignKey("Domain.Entity.Address", "SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Business", b =>
                {
                    b.HasOne("Domain.Entity.Supplier", null)
                        .WithOne("Business")
                        .HasForeignKey("Domain.Entity.Business", "SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Supplier", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Business")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}