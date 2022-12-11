using Core.IServices;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.User
{
    [RoleChecker(3)]

    public class ReturnUserModel : PageModel
    {
        private IUserAdminService _userAdminService;
        public ReturnUserModel(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }

        public IActionResult OnGet(int userId , int pageId=1 , string searchBox = "")
        {
            
            _userAdminService.ReturnUser(userId);
            return Redirect("/Admin/User/Index?pageId=" + pageId + "&searchBox="+ searchBox);
        }
    }
}
