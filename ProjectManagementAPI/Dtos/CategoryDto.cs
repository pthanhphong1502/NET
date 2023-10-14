using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
