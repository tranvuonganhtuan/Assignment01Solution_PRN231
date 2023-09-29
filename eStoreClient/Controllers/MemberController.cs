using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace eStoreClient.Controllers
{
    public class MemberController : Controller
    {
        private readonly IHttpClientFactory _client;
        private string MemberApiUrl;
        public MemberController(IHttpClientFactory client)
        {
            this._client = client;
            MemberApiUrl = "https://localhost:7153/api/Members";
        }
        // GET: MemberController
        public async Task<IActionResult> Index()
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/GetMembers";

           var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Member>>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        [HttpGet]
        public IActionResult Create()
        {
            

            return View();
        }
        
        
        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/PostMembers";

            var content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }


        // GET: MemberController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/GetMemberById/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Member>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Member member)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/UpdateMember/id";

            var content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: MemberController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/GetMemberById/" + id;

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Member>(await response.Content.ReadAsStringAsync());
                return View(result);
            }
            return View(null);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,IFormCollection collection)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/Delete/" + id;

            var response = await httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(null);
        }
    }
}
