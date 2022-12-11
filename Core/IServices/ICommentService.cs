using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ICommentService
    {
        void AddComment(string commentBody,int courseId);
        List<ShowCommentsViewModel> GetComments(int courseId);

        void AddReply(string body, int commentId);

        List<ShowCommentReplies> GetCommentReplies(int commentId);
        Tuple<List<ShowCommentsForAdminViewModel>,int> GetCommentSForAdminPanel(string filter = null, int take = 5);
        void ShowComment(int commentId);
        void NoShowComment(int commentId);
        void DeleteComment(int commentId);
        CommentBodyViewModel GetCommentBody(int commentId);
        List<ReplyCommentsBody> GetCommentRepliesForAdmin(int commentId);
        void DeleteReply(int replyId);
        void SelectTrueReply(int replyId, int commentId);

    }
}
