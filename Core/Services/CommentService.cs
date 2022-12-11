using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Domain.Models.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private IReplyCommentRepository _replyCommentRepository;
        public CommentService(ICommentRepository commentRepository, IHttpContextAccessor httpContextAccessor, IReplyCommentRepository replyCommentRepository)
        {
            _commentRepository = commentRepository;
            _httpContextAccessor = httpContextAccessor;
            _replyCommentRepository = replyCommentRepository;
        }



        public void AddComment(string commentBody, int courseId)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            _commentRepository.AddEntity(new Domain.Models.Comment.Comment()
            {
                CommentBody = commentBody,
                CommentLike = 0,
                CreateDate = DateTime.Now,
                IsDelete = false,
                Show = false,
                UserId = userId,
                CourseId = courseId,
            });
        }

        public void AddReply(string body, int commentId)
        {
            _replyCommentRepository.AddEntity(new Domain.Models.Comment.ReplyComment()
            {
                CommentId = commentId,
                CreateDate = DateTime.Now,
                ReplyBody = body,
                UserId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                u.Type == ClaimTypes.NameIdentifier).Value),

            });
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = _commentRepository.Get(c => c.CommentId == commentId).Single();
            comment.IsDelete = true;
            _commentRepository.UpdateEntity(comment);
        }

        public void DeleteReply(int replyId)
        {
            ReplyComment reply = _replyCommentRepository.Get(r => r.ReplyCommentId == replyId).Single();
            reply.IsDelete = true;
            _replyCommentRepository.UpdateEntity(reply);
        }

        public CommentBodyViewModel GetCommentBody(int commentId)
        {
            return _commentRepository.Get(c => c.CommentId == commentId).Include(c => c.User).
                Include(c => c.ReplyComments).Select(c => new CommentBodyViewModel()
                {
                    CommentId = c.CommentId,
                    BodyText = c.CommentBody,
                    CreateDate = c.CreateDate,
                    ImageName = c.User.ImageName,
                    Replies = c.ReplyComments.Where(r => !r.IsDelete).Count(),
                    UserName = c.User.UserName
                }).Single();
        }

        public List<ShowCommentReplies> GetCommentReplies(int commentId)
        {
            int? userId= int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                 u.Type == ClaimTypes.NameIdentifier).Value);

            bool isReplyForUserAsk = _commentRepository.Get(c =>
            c.CommentId == commentId && !c.IsDelete && c.UserId == userId).Any();

            return _replyCommentRepository.Get(c => c.CommentId == commentId && !c.IsDelete).Include(c => c.User).Select(c => new ShowCommentReplies()
            {
                CreateDate = c.CreateDate,
                ReplyBody = c.ReplyBody,
                UserName = c.User.UserName,
                IsAnswer = c.IsAnswer,
                IsReplyForUserAsk = isReplyForUserAsk,
                ReplyId = c.ReplyCommentId,
                
            }).OrderByDescending(c => c.CreateDate).ToList();
        }

        public List<ReplyCommentsBody> GetCommentRepliesForAdmin(int commentId)
        {
            return _replyCommentRepository.Get(r => r.CommentId == commentId && !r.IsDelete).
                Include(r => r.User).Select(r => new ReplyCommentsBody()
                {
                    CreateDate = r.CreateDate,
                    ImageName = r.User.ImageName,
                    ReplyBody = r.ReplyBody,
                    ReplyId = r.ReplyCommentId,
                    UserName = r.User.UserName
                }).ToList();
        }

        public List<ShowCommentsViewModel> GetComments(int courseId)
        {
            return _commentRepository.Get(c => c.CourseId == courseId && c.Show == true && !c.IsDelete).Include(c => c.User).
                Include(c => c.ReplyComments).OrderByDescending(c => c.CreateDate).Select(c => new ShowCommentsViewModel()
                {
                    CourseId = c.CourseId,
                    CommentId = c.CommentId,
                    CommentBody = c.CommentBody,
                    CreateDate = c.CreateDate,
                    ImageName = c.User.ImageName,
                    Like = c.CommentLike,
                    Reply = c.ReplyComments.Where(r => !r.IsDelete).Count(),
                    UserName = c.User.UserName,
                    
                }).ToList();
        }

        public Tuple<List<ShowCommentsForAdminViewModel>, int> GetCommentSForAdminPanel(string filter =null, int take=5)
        {
            
            IQueryable<Comment> comments = _commentRepository.Get(c=> !c.IsDelete).Include(c => c.User).Include(c => c.Course);
            if (filter!=null)
            {
                comments = comments.Where(c => c.Course.CourseTitle.Contains(filter) || c.User.UserName.Contains(filter));
            }
            var result = comments.Select(c => new ShowCommentsForAdminViewModel()
            {
                CommentId = c.CommentId,
                CourseId = c.CourseId,
                CourseName = c.Course.CourseTitle,
                Replyies = c.ReplyComments.Count(),
                Show = c.Show,
                UserName = c.User.UserName,
                CreateDate = c.CreateDate
            });
            return Tuple.Create(result.Take(take).ToList(), result.Count());

        }


        public void NoShowComment(int commentId)
        {
            Comment comment = _commentRepository.Get(c => c.CommentId == commentId).Single();
            comment.Show = false;
            _commentRepository.UpdateEntity(comment);
        }

        public void SelectTrueReply(int replyId, int commentId)
        {
            List<ReplyComment> replies = _replyCommentRepository.Get(r => r.CommentId == commentId).ToList();
            foreach (var reply in replies)
            {
                reply.IsAnswer = false;
                _replyCommentRepository.UpdateEntity(reply);
            }
            ReplyComment selectedReply = _replyCommentRepository.Get(r => r.ReplyCommentId == replyId).Single();
            selectedReply.IsAnswer = true;
            _replyCommentRepository.UpdateEntity(selectedReply);
        }

        public void ShowComment(int commentId)
        {
            Comment comment = _commentRepository.Get(c => c.CommentId == commentId).Single();
            comment.Show = true;
            _commentRepository.UpdateEntity(comment);
        }
    }
}
