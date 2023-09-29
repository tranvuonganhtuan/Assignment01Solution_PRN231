using BusinessObject.Models;
using eStoreClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;

namespace eStoreClient.Controllers
{
    public class ProductController : Controller
    {
       
        private readonly IHttpClientFactory _client;
        private string ProductApiUrl;


        public ProductController(IHttpClientFactory client)
        {
            this._client = client;
            ProductApiUrl = "https://localhost:7153/api/Product";
        }
        // Get: ProductController
        public async Task<IActionResult> Index()
        {

            var httClient = _client.CreateClient();
            var url = this.ProductApiUrl + "/GetProducts";
            var response = await httClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var httpClient = _client.CreateClient();

            var url = this.ProductApiUrl + "/PostProduct";

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        // GET: MemberController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.ProductApiUrl + "/GetProductById/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            var httpClient = _client.CreateClient();

            var url = this.ProductApiUrl + "/UpdateProduct/id";

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: MemberController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.ProductApiUrl + "/GetProductById/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var httpClient = _client.CreateClient();

            var url = this.ProductApiUrl + "/Delete/" + id;

            var response = await httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(null);
        }
    }
}
