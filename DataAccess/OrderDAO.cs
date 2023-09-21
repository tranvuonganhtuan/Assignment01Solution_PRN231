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
    public class OrderDAO : IGenericRepository<Order>
    {
        private readonly FStoreDBContext _context;
        private readonly IMapper _mapper;

        public OrderDAO(FStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _context.Orders.ToList();
            return _mapper.Map<List<Order>>(orders);
        }

        public Order GetById(object id)
        {
            var orderId = Convert.ToInt32(id);
            var orderEntity = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            return _mapper.Map<Order>(orderEntity);
        }

        public void Insert(Order order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _context.Orders.Add(orderEntity);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _context.Entry(orderEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var orderId = Convert.ToInt32(id);
            var existing = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (existing != null)
            {
                _context.Orders.Remove(existing);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
