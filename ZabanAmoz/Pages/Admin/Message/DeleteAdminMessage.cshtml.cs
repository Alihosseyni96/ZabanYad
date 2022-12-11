using Core.IServices;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Message
{
    [RoleChecker(3)]

    public class DeleteAdminMessageModel : PageModel
    {
        private IAdminMessageService _adminMessageService;
        public DeleteAdminMessageModel(IAdminMessageService adminMessageService)
        {
            _adminMessageService = adminMessageService;
        }


        public IActionResult OnGet(int messageId ,int pageId=1)
        {
            _adminMessageService.DeleteAdminMessage(messageId);
            return Redirect("/Admin/Message/Index?pageId=" + pageId);
        }
    }
}
