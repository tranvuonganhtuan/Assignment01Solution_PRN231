using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : IOrderDetailRepository
    {
        private List<OrderDetail> orderDetails = new List<OrderDetail>();  // Simulated data store

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return orderDetails.Where(od => od.OrderId == orderId);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetails.Add(orderDetail);
        }
    }
}
