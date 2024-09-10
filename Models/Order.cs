namespace Bangazon_BE.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Uid { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }
        public bool OrderComplete { get; set; }
        public List<Product>? Products { get; set; }

    }
}
