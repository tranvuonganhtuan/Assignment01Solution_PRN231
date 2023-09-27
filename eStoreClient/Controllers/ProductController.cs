using BusinessObject.Models;
using eStoreClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

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
    }
}
