using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Comment
{
    [RoleChecker(3)]

    public class CommentBodyModel : PageModel
    {
        private ICommentService _commentService;
        public CommentBodyModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public CommentBodyViewModel  Comment { get; set; }
        public List<ReplyCommentsBody> Replies { get; set; }
        public void OnGet(int commentId)
        {
            Comment = _commentService.GetCommentBody(commentId);
            Replies = _commentService.GetCommentRepliesForAdmin(commentId);
        }
    }
}
