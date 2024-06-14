using JWTLogin.DTO.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace JWTLogin.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _httpClient;

        public RegisterController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7177/api/Registers", userRegisterDto);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Email"] = userRegisterDto.Email;
                    return RedirectToAction("Index", "ConfirmMail");
                    
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
