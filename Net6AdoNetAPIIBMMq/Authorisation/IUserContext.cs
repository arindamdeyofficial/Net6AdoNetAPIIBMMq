using System.Threading.Tasks;

namespace Authorisation
{
    public interface IUserContext
    {
        public string CurrentUser();

        public string UserRoles(bool isDummy = false, string dummyRoleName = "");
        public string ReadTokenCurrentApplicationAsync();
        public string GenerateTokenUiApplication();
        public string GenerateTokenApiGatewayApplication();
        public string GenerateTokenConfigServiceApplication();
    }
}
