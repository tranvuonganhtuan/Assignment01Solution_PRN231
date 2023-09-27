using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/CreateMember";

            var content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }


        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Member member)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + "/UpdateMember";

            var content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var httpClient = _client.CreateClient();

            var url = this.MemberApiUrl + $"/DeleteMember/{id}";

            var response = await httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
