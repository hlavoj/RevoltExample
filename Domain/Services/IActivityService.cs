using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IActivityService
    {
        Task RecordActivity(string idOne, string idTwo);
    }
}