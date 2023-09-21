using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetOrdersByMember(int memberId);
        // Add more specific methods related to orders if needed
    }
}
