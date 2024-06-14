using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTLogin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProfileController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public  IActionResult GetAll()
        {
            return Ok("sadasdasdasdasdasdasdasdsadasdasdsadasd");
        }
    }
}
