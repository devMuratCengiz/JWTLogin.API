using JWTLogin.DTO.Dtos;
using JWTLogin.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTLogin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmMailController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmMail(ConfirmMailDto confirmMailDto)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(confirmMailDto.Email);
                if (user != null && user.ConfirmCode == confirmMailDto.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcı güncellenemedi." });
                }
                ModelState.AddModelError("", "Onay kodu geçersiz");


            }
            return BadRequest(ModelState);
        }
    }
}
