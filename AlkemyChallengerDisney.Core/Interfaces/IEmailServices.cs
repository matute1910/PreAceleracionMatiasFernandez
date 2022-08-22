using System.Threading.Tasks;

namespace ChallengerDisney.Core.Interfaces
{
    public interface IEmailServices
    {
        Task SendEmail(string email, string subject, string htmlContext);
    }
}
