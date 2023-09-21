using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetOrderDetailsByOrder(int orderId);
        // Add more specific methods related to order details if needed
    }
}
