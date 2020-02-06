using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserEmailService
    {
        Task SendMails();
    }
}