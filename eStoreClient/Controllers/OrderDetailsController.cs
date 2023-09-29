
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace eStoreClient.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IHttpClientFactory _client;
        private string OrderDetailApiUrl ;
        public OrderDetailsController(IHttpClientFactory client)
        {
            this._client = client;
            OrderDetailApiUrl = "https://localhost:7153/api/OrderDetails";
        }
        // GET: OrderDetailController
        public async Task<IActionResult> Index()
        {
            var httClient = _client.CreateClient();
            var url = this.OrderDetailApiUrl + "/GetOrderDetails";
            var response = await httClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<OrderDetail>>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // GET: OrderDetailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDetail orderDetail)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderDetailApiUrl + "/PostOrderDetail";

            var content = new StringContent(JsonConvert.SerializeObject(orderDetail), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderDetailController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderDetailApiUrl + "/GetOrderDetailsByOrderId/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<OrderDetail>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: OrderDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderDetail orderDetail)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderDetailApiUrl + "/UpdateOrderDetail/id";

            var content = new StringContent(JsonConvert.SerializeObject(orderDetail), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderDetailController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderDetailApiUrl + "/GetOrderDetailsByOrderId/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<OrderDetail>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: OrderDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderDetailApiUrl + "/Delete/" + id;

            var response = await httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(null);
        }
    }
}
