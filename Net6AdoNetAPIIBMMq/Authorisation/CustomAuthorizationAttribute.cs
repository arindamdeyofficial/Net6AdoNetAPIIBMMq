using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Authorisation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IRoleService _roleService;

        private readonly IUserContext _userContext;
        public CustomAuthorizationAttribute(IRoleService roleService, IUserContext userContext)
        {
            _roleService = roleService;
            _userContext = userContext;
        }
        /// <summary>  
        /// This will Authorize User  
        /// </summary>  
        /// <returns></returns>  
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            string[] roles = _roleService.GetRoles();
            string availableRole = _userContext.UserRoles();
            bool isAuthorized = roles.Any(s => availableRole.Contains(s));
            if (!isAuthorized)
            {
                filterContext.Result = new UnauthorizedResult();
            }

        }
    }
}
