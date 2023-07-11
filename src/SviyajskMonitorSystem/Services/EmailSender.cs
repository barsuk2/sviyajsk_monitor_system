using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using SviyajskMonitorSystem.Models.OptionModels;

namespace SviyajskMonitorSystem.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "asu_issledovanija@mail.ru"));
            emailMessage.To.Add(new MailboxAddress(email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", 465,MailKit.Security.SecureSocketOptions.Auto);
            await client.AuthenticateAsync("asu_issledovanija@mail.ru", "jctyybqrfhyfdfkcvthnb");
            
           // var res= client.Verify("timmik94@mail.ru");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
