using System.ComponentModel;

namespace eStoreClient.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        public string Weight { get; set; }

        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Units In Stock")]
        public int UnitsInStock { get; set; }
    }
}
