using System.ComponentModel.DataAnnotations;

namespace Bangazon_BE.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryType { get; set; }
    }
}
