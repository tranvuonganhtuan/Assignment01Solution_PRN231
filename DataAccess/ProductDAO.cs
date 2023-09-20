using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : IProductRepository
    {
        private List<Product> products = new List<Product>();  // Simulated data store

        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            // Update the product in the data store
            var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ProductName = product.ProductName;
                existingProduct.Weight = product.Weight;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
            }
        }

        public void DeleteProduct(int productId)
        {
            // Delete the product from the data store
            var productToRemove = products.FirstOrDefault(p => p.ProductId == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
        }
    }
}
