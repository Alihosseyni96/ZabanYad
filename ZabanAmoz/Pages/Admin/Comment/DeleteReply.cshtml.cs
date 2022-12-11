using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Comment
{
    public class DeleteReplyModel : PageModel
    {
        private ICommentService _commentService;
        public DeleteReplyModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult OnGet(int replyId , int commentId)
        {
            _commentService.DeleteReply(replyId);
            return Redirect("/Admin/Comment/CommentBody?commentId=" + commentId);
        }
    }
}
