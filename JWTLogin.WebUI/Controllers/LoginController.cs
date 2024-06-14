using JWTLogin.DTO.Dtos;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace JWTLogin.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Index(UserLoginDto userLoginDto)
         {

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7177/api/Login", userLoginDto);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                Response.Cookies.Append("Token", body, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // HTTPS üzerinden gönderilmeli
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None, // Cross-site istekler için
                    Expires = DateTime.UtcNow.AddHours(2) // Token süresi
                });
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }
    }
}
