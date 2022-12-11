using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.User
{
    [RoleChecker(3)]

    public class IndexModel : PageModel
    {
        private IUserAdminService _userAdminService;
        public IndexModel(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }

        [BindProperty]
        public string SearchBox { get; set; }
        [BindProperty]
        public int PageId { get; set; }

        public Tuple<List<ShowUsersForAdminPanelViewModel>,int , int> UsersForAdmin { get; set; }




        public void OnGet(int pageId = 1, string searchBox = "")
        {
            ViewData["SearchBox"] = searchBox;
            UsersForAdmin = _userAdminService.GetUsersForAdminPanel(pageId , searchBox);
        }

        public IActionResult OnPost()
        {
            ViewData["SearchBox"] = SearchBox;
            UsersForAdmin = _userAdminService.GetUsersForAdminPanel(PageId , SearchBox);

            return Page();
        }

    }
}
