using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order) =>OrderDAO.AddOrder(order);
        

        public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);
        

        public List<Order> GetAllOrders() => OrderDAO.GetOrders();
        

        public Order GetOrderById(int orderId) => OrderDAO.FindOrderById(orderId);
        

        public void UpdateOrder(Order order) => OrderDAO.UpdateOrder(order);
        
    }
}
