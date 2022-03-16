using MailKit.Net.Smtp;
using MailKit.Security;
using Q_Assesment1.Models;
//using MailsSender.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace Q_Assesment1.Models
{
    public class MailService:IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {

            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(mailRequest.Email);


           email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            //Adding Multiple recipient email id logic
            string[] Multi = mailRequest.ToEmail.Split(','); //spiliting input Email id string with comma (,)
            foreach (string Multiemailid in Multi)
            {
                email.To.Add(MailboxAddress.Parse(Multiemailid)); //adding multi reciver's Email Id
            }

            using var smtp = new SmtpClient();
            smtp.Connect(mailRequest.Host, mailRequest.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailRequest.Email, mailRequest.GPassword);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
