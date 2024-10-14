using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sms_Send.Models;
using Sms_Send.Services;
using System.Threading.Tasks;

namespace Sms_Send.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendSmsController : ControllerBase
    {
        [HttpPost]
        public IActionResult send(PhoneMessageDto model)
        {
            SendSms sendsms = new SendSms();

            sendsms.SendEmail(model.Number, model.Message);

            return Ok("SMS send");
        }

        [HttpPost("AddPhoneNumber")]
        public async Task<IActionResult> AddNumberAsync(PhoneNameDto model)
        {
            AddPhoneNumber addPhone = new AddPhoneNumber();

             await addPhone.AddNumber(model.FriendlyName, model.PhoneNumber);

            return Ok("Saved Phone number ");
        }
    }
}
