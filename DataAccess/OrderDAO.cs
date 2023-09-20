using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : IOrderRepository
    {
        private List<Order> orders = new List<Order>();  // Simulated data store

        public Order GetOrderById(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            // Update the order in the data store
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.MemberId = order.MemberId;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.RequiredDate = order.RequiredDate;
                existingOrder.ShippedDate = order.ShippedDate;
                existingOrder.Freight = order.Freight;
            }
        }

        public void DeleteOrder(int orderId)
        {
            // Delete the order from the data store
            var orderToRemove = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (orderToRemove != null)
            {
                orders.Remove(orderToRemove);
            }
        }
    }
}
