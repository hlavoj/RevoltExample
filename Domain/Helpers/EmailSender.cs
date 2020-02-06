using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace Domain.Helpers
{
    public class EmailSender : IEmailSender
    {
        public async Task SendMail(string toEmail, string subject, string body)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("revolt@info.com"));
            message.To.Add(new MailboxAddress(toEmail));
            message.Subject = subject;
            message.Body = new BodyBuilder {HtmlBody = body}.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587,false);
                client.Authenticate("revolttest20@gmail.com", "Test123*");
                await client.SendAsync(message).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }

        }
    }
}
