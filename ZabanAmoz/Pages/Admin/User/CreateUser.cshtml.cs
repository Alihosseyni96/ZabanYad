using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.User
{
    [RoleChecker(1)]
    public class CreateUserModel : PageModel
    {
        private IUserAdminService _userAdminService;
        public CreateUserModel(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }

        public List<ShowRolesForAdminPanelViewMode> ShowRoles { get; set; }
        [BindProperty]
        public CreateUserViewModel CreateUser { get; set; }
        public void OnGet()
        {
            ShowRoles = _userAdminService.GetRolesForShow();
        }

        public IActionResult OnPost(List<int> roleList)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                ShowRoles = _userAdminService.GetRolesForShow();
                return Page();
            }

            #endregion
            CreateUser.RolesId = roleList;
            _userAdminService.CreateUser(CreateUser);

            return RedirectToPage("Index");
        }
    }
}
