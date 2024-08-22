namespace Bangazon_BE.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public string? PaymentType { get; set; }
        public bool Status { get; set; }
        public List<Order> Orders { get; set; }

    }
}
