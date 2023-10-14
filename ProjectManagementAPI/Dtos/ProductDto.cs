using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Category? Category { get; set; }
    }
}
