﻿// <auto-generated />
using System;
using Bangazon_BE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon_BE.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    partial class BangazonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon_BE.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Shoes"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Clothes"
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<bool>("OrderComplete")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderComplete = true,
                            OrderDate = new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTypeId = 1,
                            Uid = "P9QrdmZ8cRV98APa11FmObGBjiu2"
                        },
                        new
                        {
                            OrderId = 2,
                            OrderComplete = true,
                            OrderDate = new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTypeId = 2,
                            Uid = "P9QrdmZ8cRV98APa11FmObGBjiu2"
                        },
                        new
                        {
                            OrderId = 3,
                            OrderComplete = false,
                            OrderDate = new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentTypeId = 2,
                            Uid = "P9QrdmZ8cRV98APa11FmObGBjiu2"
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Credit Card"
                        },
                        new
                        {
                            Id = 2,
                            Type = "PayPal"
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "High-quality noise-cancelling headphones with 30 hours of battery life.",
                            ImageUrl = "https://m.media-amazon.com/images/I/41JACWT-wWL._AC_UF894,1000_QL80_.jpg",
                            Price = 199.99m,
                            QuantityAvailable = 50,
                            SellerId = 1,
                            Title = "Wireless Bluetooth Headphones",
                            Uid = ""
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This athletic shoe combines style and performance, featuring a lightweight design with breathable mesh uppers for maximum ventilation.",
                            ImageUrl = "https://static.nike.com/a/images/t_PDP_936_v1/f_auto,q_auto:eco/b1bcbca4-e853-4df7-b329-5be3c61ee057/NIKE+DUNK+LOW+RETRO.png",
                            Price = 89.99m,
                            QuantityAvailable = 30,
                            SellerId = 1,
                            Title = "Nike Shoes",
                            Uid = ""
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "RGB backlit keyboard with customizable keys and fast response switches.",
                            ImageUrl = "https://hyperx.com/cdn/shop/files/hyperx_alloy_origins_us_1_top_down.jpg?v=1723777809",
                            Price = 129.99m,
                            QuantityAvailable = 75,
                            SellerId = 1,
                            Title = "Mechanical Gaming Keyboard",
                            Uid = ""
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "\r\nThis sleek and stylish watch is the perfect blend of form and function. Featuring a durable stainless steel case and a scratch-resistant crystal, it is designed to withstand everyday wear while maintaining its elegant look. .",
                            ImageUrl = "https://fossil.scene7.com/is/image/FossilPartners/BQ2457_main?$sfcc_fos_large$",
                            Price = 119.99m,
                            QuantityAvailable = 20,
                            SellerId = 2,
                            Title = "Watch",
                            Uid = ""
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "These versatile pants are designed for both comfort and style, making them a perfect addition to any wardrobe.",
                            ImageUrl = "https://i.ebayimg.com/images/g/BEcAAOSwlVpgXpQy/s-l1200.jpg",
                            Price = 39.99m,
                            QuantityAvailable = 100,
                            SellerId = 2,
                            Title = "Weird Lookin Pants",
                            Uid = ""
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("Seller")
                        .HasColumnType("boolean");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "334 South Street",
                            Email = "ross.m@coding.com",
                            FirstName = "Ross",
                            LastName = "Morgan",
                            Seller = false,
                            Uid = "",
                            UserName = "rmorgan"
                        },
                        new
                        {
                            Id = 2,
                            Address = "567 North Street",
                            Email = "asmith@coding.com",
                            FirstName = "Andrew",
                            LastName = "Smith",
                            Seller = true,
                            Uid = "",
                            UserName = "mastercoder"
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersOrderId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("Bangazon_BE.Models.Order", b =>
                {
                    b.HasOne("Bangazon_BE.Models.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId");

                    b.HasOne("Bangazon_BE.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("Bangazon_BE.Models.Product", b =>
                {
                    b.HasOne("Bangazon_BE.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("Bangazon_BE.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon_BE.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bangazon_BE.Models.PaymentType", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Bangazon_BE.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
