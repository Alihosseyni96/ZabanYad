using Core.IServices;
using Core.Security;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Comment
{
    [RoleChecker(3)]

    public class ShowCommentModel : PageModel
    {
        private ICommentService _commentService;
        public ShowCommentModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult OnGet(int commentId , int take=5, string searchKey=null)
        {
            _commentService.ShowComment(commentId);
            return Redirect("/Admin/Comment/Index?take=" + take + "&searchKey="+searchKey);
        }
    }
}
