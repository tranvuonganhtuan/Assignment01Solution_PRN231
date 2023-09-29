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
    public class OrderDetailsController : ControllerBase
    {
        private IOrderDetailRepository repository = new OrderDetailRepository();
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails() => repository.GetAllOrderDetails();

        [HttpGet("{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails =  repository.GetOrderDetailsByOrderId(orderId);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }

        [HttpPost]
        public IActionResult PostOrderDetail(OrderDetail orderDetail)
        {
            repository.AddOrderDetail(orderDetail);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ordetail = repository.GetOrderDetailsByOrderId(id);
            if (ordetail == null)
            {
                return NotFound();
            }
            repository.DeleteOrderDetail(ordetail);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            var odTmp = repository.GetOrderDetailsByOrderId(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            repository.UpdateOrderDetail(orderDetail);
            return NoContent();
        }
    }
}
