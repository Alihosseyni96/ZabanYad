using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Message
{
    [RoleChecker(3)]

    public class IndexModel : PageModel
    {
        private IAdminMessageService _adminMessageService;
        public IndexModel(IAdminMessageService adminMessageService)
        {
            _adminMessageService = adminMessageService;
        }

        public Tuple<List<ShowAdminMessageViewModel>, int> MessageList { get; set; }
        public void OnGet(int pageId= 1)
        {
            MessageList = _adminMessageService.GetAllAdminMessages(pageId);
            ViewData["CurrentPage"] = pageId;
        }
    }
}
