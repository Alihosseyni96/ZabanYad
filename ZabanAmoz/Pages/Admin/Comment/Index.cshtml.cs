using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Comment
{
    [RoleChecker(3)]
    public class IndexModel : PageModel
    {
        private ICommentService _commentService;
        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [BindProperty]
        public string SearchBox { get; set; }
        public Tuple<List<ShowCommentsForAdminViewModel>,int> Comments { get; set; }
        public void OnGet(int take=5 , string searchKey=null)
        {
            ViewData["SearchKey"] = searchKey;
            Comments = _commentService.GetCommentSForAdminPanel(searchKey, take);
        }

        public IActionResult OnPost()
        {
            Comments = _commentService.GetCommentSForAdminPanel(SearchBox);
            ViewData["SearchKey"] = SearchBox;
            return Page();
        }
    }
}
