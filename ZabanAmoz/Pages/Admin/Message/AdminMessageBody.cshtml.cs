using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Message
{
    [RoleChecker(3)]
    public class AdminMessageBodyModel : PageModel
    {
        private IAdminMessageService _adminMessageService;
        public AdminMessageBodyModel(IAdminMessageService adminMessageService)
        {
            _adminMessageService = adminMessageService;
        }


        public ShowAdminMessageBodyViewModel AdminMessagebody { get; set; }
        public void OnGet(int messageId)
        {
            AdminMessagebody = _adminMessageService.GetAdminMessageBody(messageId);

        }
    }
}
