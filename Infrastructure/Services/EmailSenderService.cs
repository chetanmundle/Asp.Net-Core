using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailSenderService
    {
        public async Task SendMail(string toEmail,string username, string subject, string message)
        {
            var apiKey = "Api key here";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("chetanmundlesd@gmail.com", "Chetan Mundle");
            //var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(toEmail, username);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
