﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace SitecSC.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Movement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MovementId");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PurchaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("SaleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("SaleId");

                    b.ToTable("Movements");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d794045c-d231-4fa5-bb51-134fca92880d"),
                            Price = 65.50m,
                            ProductId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            PurchaseId = new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"),
                            Quantity = 200
                        },
                        new
                        {
                            Id = new Guid("3c4fef43-76fe-41ae-a019-3427be36237f"),
                            Price = 34.50m,
                            ProductId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            PurchaseId = new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"),
                            Quantity = 100
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Vinos"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Fideos"
                        });
                });

            modelBuilder.Entity("Entities.Models.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PurchaseId");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("date");

                    b.Property<decimal>("PurchaseTotal")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("Id");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"),
                            PurchaseDate = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PurchaseTotal = 100m
                        });
                });

            modelBuilder.Entity("Entities.Models.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SaleId");

                    b.Property<DateTime?>("SaleDate")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<decimal>("SaleTotal")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Entities.Models.Movement", b =>
                {
                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany("Movements")
                        .HasForeignKey("ProductId");

                    b.HasOne("Entities.Models.Purchase", "Purchase")
                        .WithMany("Movements")
                        .HasForeignKey("PurchaseId");

                    b.HasOne("Entities.Models.Sale", "Sale")
                        .WithMany("Movements")
                        .HasForeignKey("SaleId");

                    b.Navigation("Product");

                    b.Navigation("Purchase");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Navigation("Movements");
                });

            modelBuilder.Entity("Entities.Models.Purchase", b =>
                {
                    b.Navigation("Movements");
                });

            modelBuilder.Entity("Entities.Models.Sale", b =>
                {
                    b.Navigation("Movements");
                });
#pragma warning restore 612, 618
        }
    }
}
