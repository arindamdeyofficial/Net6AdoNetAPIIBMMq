using BusinessModel.Config;

namespace Authorisation
{
    public class RoleService : IRoleService
    {
        /// <summary>
        /// AuthenticationConfigure
        /// </summary>
        private readonly IRoleListConfig _roleListConfig;

        public RoleService(IRoleListConfig roleListConfig)
        {
            _roleListConfig = roleListConfig;
        }
        public string[] GetRoles()
        {
            string[] userRoles = _roleListConfig.Roles.Split(',');
            return userRoles;
        }
    }
}
