using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

class SendSms
{
    public void SendEmail(string number, string msg)
    {
        string accountSid = "your account sit";
        string authToken = "your authtoken";
        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(
            new PhoneNumber($"+91{number}"))
        {
            From = new PhoneNumber("+19097570512"), // Replace with your Twilio phone number
            Body = msg, // Add your message body here
        };

        var message = MessageResource.Create(messageOptions);
        Console.WriteLine(message.Body);
    }
}
