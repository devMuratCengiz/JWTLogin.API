using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTLogin.WebUI.Controllers
{


    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _client;

        public ProfileController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["Token"];

            using (var client = _client.CreateClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7177/api/Profile")
                };
               var response = client.SendAsync(request);
            
       
                return View(response);
            }
           

        }
    }
}
