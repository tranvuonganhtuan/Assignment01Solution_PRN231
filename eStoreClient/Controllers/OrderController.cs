using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace eStoreClient.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _client;
        private string OrderApiUrl;
        public OrderController(IHttpClientFactory client)
        {

            this._client = client;
            OrderApiUrl = "https://localhost:7153/api/Orders";

        }
        public async Task<IActionResult> Index()
        {
            var httClient = _client.CreateClient();
            var url = this.OrderApiUrl + "/GetOrders";
            var response = await httClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            
            return View(null);
        }

        

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Order order)
        {
            var httpClient = _client.CreateClient();
            var url = this.OrderApiUrl + "/PostOrders";

            var content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderApiUrl + "/GetOrderById/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Order order )
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderApiUrl + "/UpdateOrders/id";
            var content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderApiUrl + "/GetOrderById/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var httpClient = _client.CreateClient();

            var url = this.OrderApiUrl + "/Delete/" + id;

            var response = await httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(null);
        }
    }
}
