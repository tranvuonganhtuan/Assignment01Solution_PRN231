using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.AddOrderDetail(orderDetail);
        

        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.DeleteOrderDetail(orderDetail);
        

        public List<OrderDetail> GetAllOrderDetails() => OrderDetailDAO.GetOrderDetails();
        

        public OrderDetail GetOrderDetailsByOrderId(int orderId) => OrderDetailDAO.FindOrderDetailById(orderId);
        

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.UpdateOrderDetail(orderDetail);
       
    }
}
