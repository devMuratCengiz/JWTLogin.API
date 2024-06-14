using JWTLogin.DTO.Dtos;
using JWTLogin.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace JWTLogin.WebUI.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly HttpClient _httpClient;

        public ConfirmMailController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index(int id)
        {
            var value = TempData["Email"];
            ViewBag.v = value;
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(ConfirmMailDto confirmMailDto)
        {
            if (ModelState.IsValid)
            {
                
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7177/api/ConfirmMail", confirmMailDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
                ModelState.AddModelError("", "Onay kodu hatalı.");
            }
            return View(confirmMailDto);
        }
    }
}
