using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BusinessModel.Common;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Authorisation
{
    [ExcludeFromCodeCoverage]
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IConfiguration _configuration;

        public UserContext(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string CurrentUser()
        {
            var username =  _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
            return username;
        }

        public string UserRoles(bool isDummy = false, string dummyRoleName = "")
        {
            List<string> roles = new List<string>();
            if (isDummy)
            {
                return dummyRoleName;
            }
            else
            {
                roles = _httpContextAccessor.HttpContext.User.Identities.SelectMany(s => s.Claims).Where(s => s.Type.Contains("role")).Select(s => s.Value).ToList();
                if (roles.Count > 1)
                {
                    //If there are multiple roles including Global admin then it will take global admin
                    string adminRole = roles.FirstOrDefault(stringToCheck => stringToCheck.Contains(ApplicationConstants.AdminRole));
                    if (adminRole != null)
                    {
                        return ApplicationConstants.AdminRole;
                    }
                    // If there are two regional admins then It will take first
                    else if (roles.FirstOrDefault(stringToCheck => stringToCheck.Contains("RegionalHead")).Any())
                    {
                        return roles.FirstOrDefault(stringToCheck => stringToCheck.Contains("RegionalHead"));
                    }
                    else
                    {
                    //If there are two site engineers then It will take first
                        return roles.FirstOrDefault(stringToCheck => stringToCheck.Contains("SiteEngineers"));
                    }
                }
                else
                {
                    return roles.FirstOrDefault();
                }
            }
        }
        public string ReadTokenCurrentApplicationAsync()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }
        public string GenerateTokenUiApplication()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }
        public string GenerateTokenApiGatewayApplication()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }
        public string GenerateTokenConfigServiceApplication()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }
    }
}
