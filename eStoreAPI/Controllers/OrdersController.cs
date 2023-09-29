using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess.Repository;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => repository.GetAllOrders();

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = repository.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult PostOrders(Order o)
        {
            repository.AddOrder(o);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p = repository.GetOrderById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteOrder(p);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrders(Order o)
        {
            var oTmp = repository.GetOrderById(o.OrderId);
            if (o == null)
            {
                return NotFound();
            }
            repository.UpdateOrder(o);
            return NoContent();
        }
    }
}
