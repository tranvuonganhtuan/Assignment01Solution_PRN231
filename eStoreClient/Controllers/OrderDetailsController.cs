
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
