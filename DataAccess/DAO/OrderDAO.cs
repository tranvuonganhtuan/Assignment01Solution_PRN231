using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDAO(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Implement specific business logic or additional methods related to Order data access if needed
        // You can use _orderRepository to interact with the data store for orders
    }
}
