using DataAccess;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;

        public OrderDetailsController(IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            var orderDetails = _orderDetailRepository.GetAll();
            return Ok(orderDetails);
        }

        [HttpGet("{orderId}/{productId}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int orderId, int productId)
        {
            var orderDetail = _orderDetailRepository.GetById(new object[] { orderId, productId });
            if (orderDetail == null)
                return NotFound();

            return orderDetail;
        }

        [HttpPut("{orderId}/{productId}")]
        public async Task<IActionResult> PutOrderDetail(int orderId, int productId, OrderDetail orderDetail)
        {
            if (orderId != orderDetail.OrderId || productId != orderDetail.ProductId)
                return BadRequest();

            _orderDetailRepository.Update(orderDetail);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Insert(orderDetail);
            _orderDetailRepository.Save();

            return CreatedAtAction("GetOrderDetail", new { orderId = orderDetail.OrderId, productId = orderDetail.ProductId }, orderDetail);
        }

        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
        {
            _orderDetailRepository.Delete(new object[] { orderId, productId });
            _orderDetailRepository.Save();

            return NoContent();
        }
    }
}
