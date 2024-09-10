using System.ComponentModel.DataAnnotations;

namespace Bangazon_BE.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Required]
        public string? Type { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
