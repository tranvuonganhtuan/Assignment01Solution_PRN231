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
    public class OrderDetailDAO : IGenericRepository<OrderDetail>
    {
        private readonly FStoreDBContext _context;
        private readonly IMapper _mapper;

        public OrderDetailDAO(FStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            var orderDetails = _context.OrderDetails.ToList();
            return _mapper.Map<List<OrderDetail>>(orderDetails);
        }

        public OrderDetail GetById(object id)
        {
            if (id is not object[] ids || ids.Length != 2)
                throw new ArgumentException("Invalid id format for OrderDetail.");

            var orderId = Convert.ToInt32(ids[0]);
            var productId = Convert.ToInt32(ids[1]);

            var orderDetailEntity = _context.OrderDetails.FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);
            return _mapper.Map<OrderDetail>(orderDetailEntity);
        }

        public void Insert(OrderDetail orderDetail)
        {
            var orderDetailEntity = _mapper.Map<OrderDetail>(orderDetail);
            _context.OrderDetails.Add(orderDetailEntity);
            _context.SaveChanges();
        }

        public void Update(OrderDetail orderDetail)
        {
            var orderDetailEntity = _mapper.Map<OrderDetail>(orderDetail);
            _context.Entry(orderDetailEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            if (id is not object[] ids || ids.Length != 2)
                throw new ArgumentException("Invalid id format for OrderDetail.");

            var orderId = Convert.ToInt32(ids[0]);
            var productId = Convert.ToInt32(ids[1]);

            var existing = _context.OrderDetails.FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);
            if (existing != null)
            {
                _context.OrderDetails.Remove(existing);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
