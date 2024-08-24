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
        public DbSet<Category> Categories { get; set; }

        public DbSet<Payment> Payment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
                {
                    new User
                    {
                            UserId = 1,
                            Name = "Ross Morgan",
                            Email = "ross.morgan@example.com",
                            Seller = false,
                            Password = "SecurePassword123"
                    },
                    new User
                    {
                            UserId = 2,
                            Name = "Andrew Smith",
                            Email = "andrew.smith@example.com",
                            Seller = false,
                            Password = "AnotherSecurePassword456"
                    }

                });
            modelBuilder.Entity<Product>().HasData(new Product[]
    {
        new Product
        {
                ProductId = 1,
                Title = "Wireless Bluetooth Headphones",
                ImageUrl = "https://media.post.rvohealth.io/2bjbp5lKTXFqsC1IaBRaVKnftUC/2024/02/23/2clpfwiF94A9rR20V9ES0nyh03C.jpeg",
                Description = "High-quality noise-cancelling headphones with 30 hours of battery life.",
                Price = 199.99m,
                QuantityAvailable = 50,
                UserId = 2,
                CategoryId = 2,
    },
        new Product
        {
                ProductId = 2,
                Title = "Nike Shoes",
                ImageUrl = "https://static.nike.com/a/images/t_PDP_936_v1/f_auto,q_auto:eco/b1bcbca4-e853-4df7-b329-5be3c61ee057/NIKE+DUNK+LOW+RETRO.png",
                Description = "This athletic shoe combines style and performance, featuring a lightweight design with breathable mesh uppers for maximum ventilation.",
                Price = 89.99m,
                QuantityAvailable = 30,
                UserId = 1,
                CategoryId = 3,
        },
        new Product
        {
                ProductId = 3,
                Title = "Mechanical Gaming Keyboard",
                ImageUrl = "https://m.media-amazon.com/images/I/61+O1VNp1-L._AC_UF894,1000_QL80_.jpg",
                Description = "RGB backlit keyboard with customizable keys and fast response switches.",
                Price = 129.99m,
                QuantityAvailable = 75,
                UserId = 1,
                CategoryId = 2,
        },
        new Product
        {
                ProductId = 4,
                Title = "Watch",
                ImageUrl = "https://fossil.scene7.com/is/image/FossilPartners/BQ2457_main?$sfcc_fos_large$",
                Description = "\r\nThis sleek and stylish watch is the perfect blend of form and function. Featuring a durable stainless steel case and a scratch-resistant crystal, it is designed to withstand everyday wear while maintaining its elegant look. .",
                Price = 119.99m,
                QuantityAvailable = 20,
                UserId = 1,
                CategoryId = 1,
        },
        new Product
        {
                ProductId = 5,
                Title = "Wireless Charging Pad",
                ImageUrl = "https://i.ebayimg.com/images/g/BEcAAOSwlVpgXpQy/s-l1200.jpg",
                Description = "These versatile pants are designed for both comfort and style, making them a perfect addition to any wardrobe.",
                Price = 39.99m,
                QuantityAvailable = 100,
                UserId = 2,
        }
    });
            modelBuilder.Entity<Order>().HasData(new Order[]
    {
        new Order
        {
                OrderId = 1,
                OrderDate = new DateTime(2024, 8, 15),
                UserId = 1,
                PaymentType = "Debit",
                Status = true,
    },

        new Order
        {
                OrderId = 2,
                OrderDate = new DateTime(2024, 8, 18),
                UserId = 2,
                PaymentType = "Credit",
                Status = true,
        }
    });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryType = "Accessories"
                },
                
                new Category
                {
                    CategoryId = 2,
                    CategoryType = "Electronics"
                },
                
                new Category
                {
                    CategoryId = 3,
                    CategoryType = "Shoes"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryType = "Clothes"
                }

            });
            modelBuilder.Entity<Payment>().HasData(new Payment[]
            {
                new Payment {
                    PaymentId = 1,
                    PaymentType = "Credit", 
                },
                new Payment {
                    PaymentId = 2,
                    PaymentType = "Debit",
                },
                new Payment {
                    PaymentId = 3,
                    PaymentType = "Paypal",
                }
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
