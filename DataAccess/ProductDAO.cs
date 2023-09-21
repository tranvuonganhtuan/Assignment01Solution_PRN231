using AutoMapper;
using BusinessObject;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : IGenericRepository<Product>
    {
        private readonly FStoreDBContext _context;
        private readonly IMapper _mapper;

        public ProductDAO(FStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _context.Products.ToList();
            return _mapper.Map<List<Product>>(products);
        }

        public Product GetById(object id)
        {
            var productId = Convert.ToInt32(id);
            var productEntity = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            return _mapper.Map<Product>(productEntity);
        }

        public void Insert(Product product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _context.Products.Add(productEntity);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _context.Entry(productEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var productId = Convert.ToInt32(id);
            var existing = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (existing != null)
            {
                _context.Products.Remove(existing);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
