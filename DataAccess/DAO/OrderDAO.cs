using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    orders = context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public static Order FindOrderById(int orderId)
        {
            Order o = new Order();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    o = context.Orders.SingleOrDefault(x => x.OrderId == orderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return o;
        }

        public static Member FindMemberById(int memberId)
        {
            Member o = new Member();
            try
            {
                using (var context = new FStoreDBContext())
                {
                    o = context.Members.SingleOrDefault(x => x.MemberId == memberId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return o;
        }
        public static void AddOrder(Order order)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new FStoreDBContext())
                {
                    var p1 = context.Orders.SingleOrDefault(p => p.OrderId == order.OrderId);
                    context.Orders.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
