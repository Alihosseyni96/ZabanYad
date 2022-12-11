using Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security
{
    public class RoleCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IPermissionService _permissionService;
        private int _RoleId;
        public RoleCheckerAttribute(int roleId)
        {
            _RoleId = roleId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (_permissionService.CheckRole(_RoleId)==false)
                {
                    context.Result = new RedirectResult("/Account/Login");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}
