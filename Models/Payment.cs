using System.ComponentModel.DataAnnotations;

namespace Bangazon_BE.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        
        public string? PaymentType { get; set; }
    }
}
