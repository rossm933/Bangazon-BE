namespace Bangazon_BE.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Image { get; set; }
        public string? ProductType { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SellerId { get; set; }
    }
}
