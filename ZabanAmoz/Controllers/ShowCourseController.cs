using Core.IServices;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ZabanAmoz.Controllers
{
    public class ShowCourseController : Controller
    {
        private ICourseService _courseService;
        private ICommentService _commentService;
        private IBuyCourseService _buyCourseService;
        private IRateCourseService _rateCourseService;
        public ShowCourseController(ICourseService courseService, ICommentService commentService,
            IBuyCourseService buyCourseService, IRateCourseService rateCourseService)
        {
            _courseService = courseService;
            _commentService = commentService;
            _buyCourseService = buyCourseService;
            _rateCourseService = rateCourseService;
        }

        public IActionResult Index(int courseId , bool commentStatus = false , bool replyStatus = false)
        {
            ShowCourseDetialsViewModel showCourse =
                _courseService.GetCourseToShow(courseId);
            ViewBag.CommentStatus = commentStatus;
            ViewBag.ReplyStatus = replyStatus;
            ViewBag.UserCourse = _buyCourseService.UserExistInCourse(courseId);
            ViewBag.CourseRate = _rateCourseService.GetCourseRate(courseId);
            return View(showCourse);
        }

        public IActionResult CreateComment(string body,int courseId)
        {
            if (body=="")
            {
                return NotFound();
            }
            _commentService.AddComment(body,courseId);
            return Redirect("/ShowCourse/Index?courseId="+ courseId+"&commentStatus="+true);
        }

        public IActionResult ShowComments(int courseId , bool replyStatus = false)
        {
            List<ShowCommentsViewModel> comments = 
                _commentService.GetComments(courseId);
            ViewBag.ReplyStatus = replyStatus;
            return PartialView(comments);
        }

        public IActionResult CreateReply(string replyBody , int commentId , int courseId)
        {
            if (replyBody==null)
            {
                return NotFound();
            }
            _commentService.AddReply(replyBody, commentId);
            return Redirect("/ShowCourse/Index?courseId=" + courseId +"&replyStatus="+true);
        }
        
        public IActionResult SelectTrueReply(int replyId , int commentId , int coreseId)
        {
            _commentService.SelectTrueReply(replyId, commentId);
            return Redirect("/ShowCourse/Index?courseId="+coreseId);
        }



        public IActionResult RateCourse(int courseId , int rate)
        {
            if (rate> 5 || rate < 1)
            {
                return NotFound();
            }
            _rateCourseService.RateCourse(courseId, rate);
            return Redirect("/ShowCourse/Index?courseId=" + courseId);
        }
    }
}
