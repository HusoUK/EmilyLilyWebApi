using EmilyLilyApi.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmilyLilyApi.Services
{
    public class Emailer : IMessenger
    {
        private readonly IConfiguration _config;

        public Emailer(IConfiguration config)
        {
            _config = config;
        }

        public void SendMessage(IMessage msg)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(msg.Email));
            email.To.Add(MailboxAddress.Parse(_config.GetSection("EmailRecipient").Value));
            email.Subject = $"Website e-mail from: {msg.FirstName} {msg.LastName}";
            email.Body = new TextPart(TextFormat.Html) { Text = msg.Message };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, _config.GetValue<int>("EmailPort"), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
