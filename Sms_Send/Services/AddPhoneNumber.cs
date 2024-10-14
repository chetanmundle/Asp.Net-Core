using System;
using Twilio.Rest.Api.V2010.Account;
using Twilio;
using System.Threading.Tasks;

namespace Sms_Send.Services
{
    public class AddPhoneNumber
    {
        public async Task AddNumber(string friendluname , string number)
        {

            string accountSid = "your account sit";
            string authToken = "your authtoken";

            TwilioClient.Init(accountSid, authToken);

            var validationRequest = await ValidationRequestResource.CreateAsync(
                friendlyName: friendluname,
                phoneNumber: new Twilio.Types.PhoneNumber($"+91{number}"));

            Console.WriteLine(validationRequest.AccountSid);
        }
    }
}
