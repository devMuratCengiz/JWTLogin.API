using JWTLogin.API.JWT;
using JWTLogin.DTO.Dtos;
using JWTLogin.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTLogin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userLoginDto.Username);
                if (user.EmailConfirmed ==true)
                {
                    BuildToken build = new BuildToken();
                    var token = build.CreateToken(user);
                 
                    return Ok(token);
                }
                return BadRequest(new {Message = "Email not confirmed"});
            }
            return BadRequest(new { Message = "Invalid login attempt" });
        }
    }
}
