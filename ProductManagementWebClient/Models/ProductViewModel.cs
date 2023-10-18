using System.ComponentModel;

namespace ProductManagementWebClient.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
