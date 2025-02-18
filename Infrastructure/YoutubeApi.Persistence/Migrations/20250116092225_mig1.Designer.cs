﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YoutubeApi.Persistence.Context;

#nullable disable

namespace YoutubeApi.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250116092225_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("YoutubeApi.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 452, DateTimeKind.Local).AddTicks(1372),
                            IsDeleted = false,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 452, DateTimeKind.Local).AddTicks(5749),
                            IsDeleted = false,
                            Name = "Industrial & Music"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 452, DateTimeKind.Local).AddTicks(5972),
                            IsDeleted = true,
                            Name = "Grocery, Home & Home"
                        });
                });

            modelBuilder.Entity("YoutubeApi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 453, DateTimeKind.Local).AddTicks(9083),
                            IsDeleted = false,
                            Name = "Elektrik",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 453, DateTimeKind.Local).AddTicks(9092),
                            IsDeleted = false,
                            Name = "Moda",
                            ParentId = 0,
                            Priorty = 2
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 453, DateTimeKind.Local).AddTicks(9090),
                            IsDeleted = false,
                            Name = "Bilgisayar",
                            ParentId = 1,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 453, DateTimeKind.Local).AddTicks(9094),
                            IsDeleted = false,
                            Name = "Kadın",
                            ParentId = 2,
                            Priorty = 1
                        });
                });

            modelBuilder.Entity("YoutubeApi.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Detail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 476, DateTimeKind.Local).AddTicks(7384),
                            Description = "Consequatur değirmeni ötekinden layıkıyla dolores.",
                            IsDeleted = false,
                            Title = "Ama."
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 476, DateTimeKind.Local).AddTicks(7548),
                            Description = "Sokaklarda reprehenderit yaptı gülüyorum laboriosam.",
                            IsDeleted = true,
                            Title = "Şafak sıfat."
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 476, DateTimeKind.Local).AddTicks(7620),
                            Description = "Sıla gazete çorba ex ratione.",
                            IsDeleted = false,
                            Title = "Ea."
                        });
                });

            modelBuilder.Entity("YoutubeApi.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 485, DateTimeKind.Local).AddTicks(9485),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Discount = 5.968374639833280m,
                            IsDeleted = false,
                            Price = 194.33m,
                            Title = "Refined Concrete Mouse"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreateDate = new DateTime(2025, 1, 16, 12, 22, 24, 485, DateTimeKind.Local).AddTicks(9703),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Discount = 1.949549961580720m,
                            IsDeleted = false,
                            Price = 281.05m,
                            Title = "Licensed Concrete Pizza"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("YoutubeApi.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YoutubeApi.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YoutubeApi.Domain.Entities.Detail", b =>
                {
                    b.HasOne("YoutubeApi.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("YoutubeApi.Domain.Entities.Product", b =>
                {
                    b.HasOne("YoutubeApi.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("YoutubeApi.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
