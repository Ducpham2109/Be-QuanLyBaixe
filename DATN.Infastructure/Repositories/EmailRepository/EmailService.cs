using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.EmailReponsitory
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public class MailSettings
        {
            public string Mail { get; set; }
            public string DisplayName { get; set; }
            public string Password { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }
        }
        public async Task ForgotPassWordAsync(string toEmail, string body)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "FORGOT PASSWORD";
            var builder = new BodyBuilder();

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
}
