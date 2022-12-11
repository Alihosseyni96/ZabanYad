using Core.IServices;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Comment
{
    [RoleChecker(3)]

    public class DeleteCommentModel : PageModel
    {
        private ICommentService _commentService;
        public DeleteCommentModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult OnGet(int commentId , int take = 5, string searchKey=null)
        {
            _commentService.DeleteComment(commentId);
            return Redirect("/Admin/Comment/Index?take=" + take + "&searchKey=" + searchKey);
        }
    }
}
