using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    listOrderDetails = context.OrderDetails.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrderDetails;
        }
        public static OrderDetail FindOrderDetailById(int orderDetailId)
        {
            OrderDetail orderDetail = new OrderDetail();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    orderDetail = context.OrderDetails.SingleOrDefault(c => c.OrderId == orderDetailId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetail;
        }
        public static void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var p1 = context.OrderDetails.SingleOrDefault(c => c.OrderId == orderDetail.OrderId);
                    context.OrderDetails.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
