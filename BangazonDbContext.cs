using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using static System.Net.WebRequestMethods;

namespace Bangazon_BE
{
    public class BangazonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
                {
                    new User
                    {
                        Id = 1, 
                        Uid = "", 
                        FirstName = "Ross", 
                        LastName = "Morgan", 
                        UserName = "rmorgan", 
                        Address = "334 South Street", 
                        Email = "ross.m@coding.com", 
                        Seller = false
                    },
                    new User
                    {
                        Id = 2,
                        Uid = "",
                        FirstName = "Andrew",
                        LastName = "Smith",
                        UserName = "mastercoder",
                        Address = "567 North Street",
                        Email = "asmith@coding.com",
                        Seller = true
                    }

                });
            modelBuilder.Entity<Product>().HasData(new Product[]
    {
        new Product
        {
                ProductId = 1,
                Title = "Wireless Bluetooth Headphones",
                ImageUrl = "https://m.media-amazon.com/images/I/41JACWT-wWL._AC_UF894,1000_QL80_.jpg",
                Description = "High-quality noise-cancelling headphones with 30 hours of battery life.",
                Price = 199.99m,
                QuantityAvailable = 50,
                Uid = "",
                CategoryId = 2,
                SellerId = 1,
    },
        new Product
        {
                ProductId = 2,
                Title = "Nike Shoes",
                ImageUrl = "https://static.nike.com/a/images/t_PDP_936_v1/f_auto,q_auto:eco/b1bcbca4-e853-4df7-b329-5be3c61ee057/NIKE+DUNK+LOW+RETRO.png",
                Description = "This athletic shoe combines style and performance, featuring a lightweight design with breathable mesh uppers for maximum ventilation.",
                Price = 89.99m,
                QuantityAvailable = 30,
                Uid = "",
                CategoryId = 3,
                SellerId = 1,

        },
        new Product
        {
                ProductId = 3,
                Title = "Mechanical Gaming Keyboard",
                ImageUrl = "https://hyperx.com/cdn/shop/files/hyperx_alloy_origins_us_1_top_down.jpg?v=1723777809",
                Description = "RGB backlit keyboard with customizable keys and fast response switches.",
                Price = 129.99m,
                QuantityAvailable = 75,
                Uid = "",
                CategoryId = 2,
                SellerId = 1,

        },
        new Product
        {
                ProductId = 4,
                Title = "Watch",
                ImageUrl = "https://fossil.scene7.com/is/image/FossilPartners/BQ2457_main?$sfcc_fos_large$",
                Description = "\r\nThis sleek and stylish watch is the perfect blend of form and function. Featuring a durable stainless steel case and a scratch-resistant crystal, it is designed to withstand everyday wear while maintaining its elegant look. .",
                Price = 119.99m,
                QuantityAvailable = 20,
                Uid = "",
                CategoryId = 1,
                SellerId = 2,
        },
        new Product
        {
                ProductId = 5,
                Title = "Weird Lookin Pants",
                ImageUrl = "https://i.ebayimg.com/images/g/BEcAAOSwlVpgXpQy/s-l1200.jpg",
                Description = "These versatile pants are designed for both comfort and style, making them a perfect addition to any wardrobe.",
                Price = 39.99m,
                QuantityAvailable = 100,
                Uid = "",
                CategoryId = 2,
                SellerId = 2,

        }
    });
            modelBuilder.Entity<Order>().HasData(new Order[]
    {
        new Order
        {
                OrderId = 1,
                OrderDate = new DateTime(2024, 8, 15),
                Uid = "P9QrdmZ8cRV98APa11FmObGBjiu2",
                PaymentTypeId = 1,
                OrderComplete = true,
    },

        new Order
        {
                OrderId = 2,
                OrderDate = new DateTime(2024, 8, 18),
                Uid = "P9QrdmZ8cRV98APa11FmObGBjiu2",
                PaymentTypeId = 2,
                OrderComplete = true,
        },
                new Order
        {
                OrderId = 3,
                OrderDate = new DateTime(2024, 8, 18),
                Uid = "P9QrdmZ8cRV98APa11FmObGBjiu2",
                PaymentTypeId = 2,
                OrderComplete = false,
        }
    });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category
                {
                    Id = 1,
                    Name = "Accessories"
                },
                
                new Category
                {
                    Id = 2,
                    Name = "Electronics"
                },
                
                new Category
                {
                    Id = 3,
                    Name = "Shoes"
                },
                new Category
                {
                    Id = 4,
                    Name = "Clothes"
                }

            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
        new PaymentType { Id = 1, Type = "Credit Card" },
        new PaymentType { Id = 2, Type = "PayPal" }
            });





            modelBuilder.Entity<Order>()
           .HasMany(order => order.Products)
           .WithMany(product => product.Orders)
           .UsingEntity(x => x.ToTable("OrderProduct"));

        }

        public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
        {

        }



    }
}
