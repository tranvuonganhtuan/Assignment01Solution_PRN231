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
        Uri baseAddress = new Uri("http://localhost:44314/api");
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<ProductViewModel> productList = new List<ProductViewModel>();
                HttpResponseMessage response = _httpClient.GetAsync("product/Get").Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    productList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
                }
                else
                {
                    // Log the error
                    Console.WriteLine("Error accessing the API: " + response.ReasonPhrase);
                    // You might want to log this error in a file or a logging system
                }

                return View(productList);
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("An error occurred: " + ex.Message);
                return View(new List<ProductViewModel>());
            }
        }
    }
}
