using System.Threading.Tasks;

namespace Authorisation
{
    /// <summary>
    /// ITokenClient
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// GetTokenforConfigApplication
        /// </summary>
        /// <returns></returns>
        public Task<string> GetTokenforConfigApplication();
    }
}
