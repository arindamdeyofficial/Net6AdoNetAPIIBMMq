using System.Threading.Tasks;

namespace Authorisation
{
    public interface ITokenNotificationService
    {
        public Task<string> GetToken();
    }
}
