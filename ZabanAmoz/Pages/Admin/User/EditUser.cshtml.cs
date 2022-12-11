using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.User
{
    [RoleChecker(1)]

    public class EditUserModel : PageModel
    {
        private IUserAdminService _userAdminService;
        public EditUserModel(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }

        [BindProperty]
        public UserForEditAdminViewModel UserForEdit { get; set; }
        public List<ShowRolesForAdminPanelViewMode> ShowRoles { get; set; }

        public int UserId { get; set; }

        public void OnGet( int userId)
        {
            UserForEdit = _userAdminService.GetUserForEdit(userId);
            ShowRoles = _userAdminService.GetRolesForShow();
            UserId = userId;

        }

        public IActionResult OnPost(List<int> roleList)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                UserForEdit = _userAdminService.GetUserForEdit(UserForEdit.UserId);
                ShowRoles = _userAdminService.GetRolesForShow();
                return Page();
            }

            #endregion

            UserForEdit.RolesId = roleList;
            _userAdminService.EditUser(UserForEdit);
            return RedirectToPage("Index");
        }
    }
}
