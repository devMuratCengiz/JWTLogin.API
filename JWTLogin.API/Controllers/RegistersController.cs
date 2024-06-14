using JWTLogin.DTO.Dtos;
using JWTLogin.Entity.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace JWTLogin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public RegistersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task <IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);
                AppUser user = new AppUser()
                {
                    UserName = userRegisterDto.UserName,
                    Email = userRegisterDto.Email,
                    ConfirmCode = code
                };

                var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "mcengiz0777@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User",user.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Confirm code : " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Confirm Code";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("mcengiz0777@gmail.com", "rity dbjv kiuf ekzd");
                    client.Send(mimeMessage);
                    client.Disconnect(true);


                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
