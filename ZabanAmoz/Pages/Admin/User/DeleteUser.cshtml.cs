using Core.IServices;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.User
{
    [RoleChecker(3)]
    public class DeleteUserModel : PageModel
    {
        private IUserAdminService _userAdminService;
        public DeleteUserModel(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }

        public IActionResult OnGet(int userId , int pageId=1 , string searchBox=null)
        {
            _userAdminService.DeleteUser(userId);
            return Redirect("/Admin/User/Index?pageId=" + pageId + "&searchBox="+ searchBox);

        }
    }
}
