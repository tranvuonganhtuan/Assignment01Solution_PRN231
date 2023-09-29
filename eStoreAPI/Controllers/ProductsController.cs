
using BusinessObject.Models;

using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetAllProducts();
        [HttpPost]
        public ActionResult PostProduct(Product p)
        {
            repository.AddProduct(p);
            return NoContent();
        }
        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            var product = repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(product);
            return NoContent();
        }
        [HttpPut("id")]
        public ActionResult UpdateProduct(Product p, int id)
        {
            var pTmp = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}
