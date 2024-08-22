using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;

namespace Bangazon_BE
{
    public class BangazonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
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
        },
        new Product
        {
                ProductId = 2,
                Title = "4K Ultra HD Monitor",
                ImageUrl = "https://cdn.thewirecutter.com/wp-content/media/2023/06/4kmonitors-2048px-9794.jpg",
                Description = "27-inch monitor with vibrant colors and fast response time, perfect for gaming and productivity.",
                Price = 349.99m,
                QuantityAvailable = 30,
                UserId = 1,
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
        },
        new Product
        {
                ProductId = 4,
                Title = "High-Performance Gaming Laptop",
                ImageUrl = "https://i.pcmag.com/imagery/reviews/043DROGFihmSgG7S6LUb006-1..v1709854231.jpg",
                Description = "15.6-inch gaming laptop with Intel i7 processor, 16GB RAM, and NVIDIA GTX 1660 Ti graphics card.",
                Price = 1199.99m,
                QuantityAvailable = 20,
                UserId = 1,
        },
        new Product
        {
                ProductId = 5,
                Title = "Wireless Charging Pad",
                ImageUrl = "https://m.media-amazon.com/images/I/51YD0CM1PnL._AC_UF894,1000_QL80_.jpg",
                Description = "Fast wireless charger compatible with all Qi-enabled devices.",
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
                TotalAmount = 199.99m,
                UserId = 1,
                PaymentType = "Debit",
                Status = true,
    },

        new Order
        {
            OrderId = 2,
            OrderDate = new DateTime(2024, 8, 18),
            TotalAmount = 349.99m,
            UserId = 2,
            PaymentType = "Credit",
            Status = false,
        }
    });
        }
        public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
        {

        }



    }
}
