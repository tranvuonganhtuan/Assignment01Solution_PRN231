using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        private readonly IProductRepository _productRepository;

        public ProductDAO(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Implement specific business logic or additional methods related to Product data access if needed
        // You can use _productRepository to interact with the data store for products
    }
}
