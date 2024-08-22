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

            modelBuilder.Entity("Bangazon_BE.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<decimal>("totalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderDate = new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentType = "Debit",
                            Status = true,
                            UserId = 1,
                            totalAmount = 199.99m
                        },
                        new
                        {
                            OrderId = 2,
                            OrderDate = new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentType = "Credit",
                            Status = false,
                            UserId = 2,
                            totalAmount = 349.99m
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

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

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "High-quality noise-cancelling headphones with 30 hours of battery life.",
                            ImageUrl = "https://media.post.rvohealth.io/2bjbp5lKTXFqsC1IaBRaVKnftUC/2024/02/23/2clpfwiF94A9rR20V9ES0nyh03C.jpeg",
                            Price = 199.99m,
                            QuantityAvailable = 50,
                            Title = "Wireless Bluetooth Headphones",
                            UserId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "27-inch monitor with vibrant colors and fast response time, perfect for gaming and productivity.",
                            ImageUrl = "https://cdn.thewirecutter.com/wp-content/media/2023/06/4kmonitors-2048px-9794.jpg",
                            Price = 349.99m,
                            QuantityAvailable = 30,
                            Title = "4K Ultra HD Monitor",
                            UserId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "RGB backlit keyboard with customizable keys and fast response switches.",
                            ImageUrl = "https://m.media-amazon.com/images/I/61+O1VNp1-L._AC_UF894,1000_QL80_.jpg",
                            Price = 129.99m,
                            QuantityAvailable = 75,
                            Title = "Mechanical Gaming Keyboard",
                            UserId = 1
                        },
                        new
                        {
                            ProductId = 4,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "15.6-inch gaming laptop with Intel i7 processor, 16GB RAM, and NVIDIA GTX 1660 Ti graphics card.",
                            ImageUrl = "https://i.pcmag.com/imagery/reviews/043DROGFihmSgG7S6LUb006-1..v1709854231.jpg",
                            Price = 1199.99m,
                            QuantityAvailable = 20,
                            Title = "High-Performance Gaming Laptop",
                            UserId = 1
                        },
                        new
                        {
                            ProductId = 5,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fast wireless charger compatible with all Qi-enabled devices.",
                            ImageUrl = "https://m.media-amazon.com/images/I/51YD0CM1PnL._AC_UF894,1000_QL80_.jpg",
                            Price = 39.99m,
                            QuantityAvailable = 100,
                            Title = "Wireless Charging Pad",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<bool>("Seller")
                        .HasColumnType("boolean");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "ross.morgan@example.com",
                            Name = "Ross Morgan",
                            Password = "SecurePassword123",
                            Seller = false
                        },
                        new
                        {
                            UserId = 2,
                            Email = "andrew.smith@example.com",
                            Name = "Andrew Smith",
                            Password = "AnotherSecurePassword456",
                            Seller = false
                        });
                });

            modelBuilder.Entity("Bangazon_BE.Models.Product", b =>
                {
                    b.HasOne("Bangazon_BE.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
