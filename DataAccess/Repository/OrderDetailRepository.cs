using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly FStoreDBContext _dbContext;

        public OrderDetailRepository(FStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderDetail GetOrderDetailById(int orderId, int productId)
        {
            return _dbContext.OrderDetails.FirstOrDefault(o => o.OrderId == orderId && o.ProductId == productId);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _dbContext.OrderDetails.ToList();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Add(orderDetail);
            _dbContext.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Update(orderDetail);
            _dbContext.SaveChanges();
        }

        public void DeleteOrderDetail(int orderId, int productId)
        {
            var orderDetail = _dbContext.OrderDetails.FirstOrDefault(o => o.OrderId == orderId && o.ProductId == productId);
            if (orderDetail != null)
            {
                _dbContext.OrderDetails.Remove(orderDetail);
                _dbContext.SaveChanges();
            }
        }
    }
}
