using BusinessObject;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class OrderAPI : ControllerBase
{
    private readonly IOrderRepository orderRepository;

    public OrderAPI(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    // GET: api/OrderAPI
    [HttpGet]
    public IEnumerable<Order> Get()
    {
        return orderRepository.GetAllOrders();
    }

    // GET: api/OrderAPI/5
    [HttpGet("{id}", Name = "GetOrder")]
    public Order Get(int id)
    {
        return orderRepository.GetOrderById(id);
    }

    // POST: api/OrderAPI
    [HttpPost]
    public void Post([FromBody] Order order)
    {
        orderRepository.AddOrder(order);
    }

    // PUT: api/OrderAPI/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Order order)
    {
        // Ensure the provided order has the correct ID
        if (id != order.OrderId)
            return;

        orderRepository.UpdateOrder(order);
    }

    // DELETE: api/OrderAPI/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        orderRepository.DeleteOrder(id);
    }
}
