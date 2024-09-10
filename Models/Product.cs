using System.ComponentModel.DataAnnotations;

namespace Bangazon_BE.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int CategoryId { get; set; }

        public int SellerId { get; set; }

        public DateTime DateAdded { get; set; }
        public string? Uid { get; set; }

        public List<Order>? Orders { get; set; }

         public Category? Category { get; set; }

    }
}
