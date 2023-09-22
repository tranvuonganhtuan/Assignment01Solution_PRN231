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
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailDAO(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        // Implement specific business logic or additional methods related to OrderDetail data access if needed
        // You can use _orderDetailRepository to interact with the data store for order details
    }
}
