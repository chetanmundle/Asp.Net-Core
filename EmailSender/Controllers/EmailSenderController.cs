using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using App.Core.Models.Email;
using Infrastructure.Services;


namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail(EmailRequestDto model)
        {
            EmailSenderService emailSenderService = new EmailSenderService();

            await emailSenderService.SendMail(model.ToEmail, model.Username, model.Subject, model.Message);

            return Ok("Email Send ");
        }
    }
}
