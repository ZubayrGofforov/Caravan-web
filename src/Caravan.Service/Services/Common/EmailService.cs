using Caravan.Service.Interfaces.Common;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;


namespace Caravan.Service.Services.Common
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            this._config = config.GetSection("EmailSettings");
        }

        public async Task<bool> SendAsync(Dtos.Common.EmailMessage emailMessage)
        {
            var mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse(_config["Email"]));
            mail.To.Add(MailboxAddress.Parse(emailMessage.To));
            mail.Subject = emailMessage.Subject;
            mail.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body };

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["Host"], int.Parse(_config["Port"]), MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["Email"], _config["Password"]);
            await smtp.SendAsync(mail);
            await smtp.DisconnectAsync(true);
            return true;
        }
    }
}
