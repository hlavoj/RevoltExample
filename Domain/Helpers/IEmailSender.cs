using System.Threading.Tasks;

namespace Domain.Helpers
{
    public interface IEmailSender
    {
        Task SendMail(string toEmail, string subject, string body);
    }
}