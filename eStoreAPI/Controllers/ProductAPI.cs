using BusinessObject;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ProductAPI : ControllerBase
{
    private readonly IProductRepository productRepository;

    public ProductAPI(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    // GET: api/ProductAPI
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return productRepository.GetAllProducts();
    }

    // GET: api/ProductAPI/5
    [HttpGet("{id}", Name = "GetProduct")]
    public Product Get(int id)
    {
        return productRepository.GetProductById(id);
    }

    // POST: api/ProductAPI
    [HttpPost]
    public void Post([FromBody] Product product)
    {
        productRepository.AddProduct(product);
    }

    // PUT: api/ProductAPI/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Product product)
    {
        // Ensure the provided product has the correct ID
        if (id != product.ProductId)
            return;

        productRepository.UpdateProduct(product);
    }

    // DELETE: api/ProductAPI/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        productRepository.DeleteProduct(id);
    }
}
