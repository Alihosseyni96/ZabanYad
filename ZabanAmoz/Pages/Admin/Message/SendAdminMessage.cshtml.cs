using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Message
{
    [RoleChecker(3)]

    public class SendAdminMessageModel : PageModel
    {
        private IUserAdminService _userAdminService;
        private IAdminMessageService _adminMessageService;

        public SendAdminMessageModel(IUserAdminService userAdminService, IAdminMessageService adminMessageService)
        {
            _userAdminService = userAdminService;
            _adminMessageService = adminMessageService;
        }



        [BindProperty]
        public CreateAdminMessageViewModel  AdminMessage { get; set; }
        public List<ShowRolesForAdminPanelViewMode> Roles { get; set; }
        public void OnGet()
        {
            Roles = _userAdminService.GetRolesForShow();
        }

        public IActionResult OnPost(List<int> roleList)
        {
            #region Validations
            if (!ModelState.IsValid || roleList == null)
            {
                if (roleList == null)
                {
                    ModelState.AddModelError("roleList", "گیرندگان را مشخص کنید");
                }
                Roles = _userAdminService.GetRolesForShow();
                return Page();
            }
            #endregion
            AdminMessage.RecieverRoles = roleList;
            _adminMessageService.SendAdminMessage(AdminMessage);
            return RedirectToPage("Index");
        }


    }
}
