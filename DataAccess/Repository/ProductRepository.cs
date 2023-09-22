using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.AddProduct(product);
        

        public void DeleteProduct(Product product) => ProductDAO.DeleteProduct(product);
        

        public List<Product> GetAllProducts() => ProductDAO.GetProducts();
       

        public Product GetProductById(int productId) => ProductDAO.FindProductById(productId);
        

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);    
        
    }
}
