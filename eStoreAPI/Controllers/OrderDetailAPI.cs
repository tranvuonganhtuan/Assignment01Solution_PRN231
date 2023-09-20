using BusinessObject;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailAPI : ControllerBase
{
    private readonly IOrderDetailRepository orderDetailRepository;

    public OrderDetailAPI(IOrderDetailRepository orderDetailRepository)
    {
        this.orderDetailRepository = orderDetailRepository;
    }

    // GET: api/OrderDetailAPI/{orderId}
    [HttpGet("{orderId}")]
    public IEnumerable<OrderDetail> Get(int orderId)
    {
        return orderDetailRepository.GetOrderDetailsByOrderId(orderId);
    }

    // POST: api/OrderDetailAPI
    [HttpPost]
    public void Post([FromBody] OrderDetail orderDetail)
    {
        orderDetailRepository.AddOrderDetail(orderDetail);
    }
}
