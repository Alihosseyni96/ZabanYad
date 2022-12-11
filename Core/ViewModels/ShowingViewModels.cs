using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{

    public class ShowGroupsViewModel
    {
        public int GroupId { get; set; }
        public int? ParrentId { get; set; }
        public string GroupTitle { get; set; }
        public int CourseCount { get; set; }
    }

    public class ShowCourseViewModel
    {
        public int CourseId { get; set; }
        public string ImageName { get; set; }
        public int Price { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public TimeSpan TotalTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Visit { get; set; }
        public int Sale { get; set; }
        public bool IsLike { get; set; }
        public CourseRateViewModel CourseRate { get; set; }
    }

    public class EpisodeViewModel
    {
        public int EpisodeId { get; set; }
        public string EpisodeTitle { get; set; }
        public bool IsFree { get; set; }
        public string EpisodeFileName { get; set; }
        public TimeSpan EpisodeTime { get; set; }
    }
    public class ShowCourseDetialsViewModel
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public Domain.MyEnums.CourseLevel CourseLevel { get; set; }
        public Domain.MyEnums.CourseStatus CourseStatus { get; set; }
        public int CoursePrice { get; set; }
        public string CourseText { get; set; }
        public string TeacherName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string ImageName { get; set; }
        public string DemoFileName { get; set; }
        public TimeSpan? CourseTime { get; set; }
        public string? AuthenticatedUserImageName { get; set; }
        public string? AuthenticatedUserName { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; }
        public bool UserPuechesedCourse { get; set; }
        public bool UserIdAuthenticated { get; set; }
    }

    public class CreateCommentViewModel
    {
        [Display(Name = "متن نظر ")]
        [MaxLength(850, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CommentBody { get; set; }
        public int CourseId { get; set; }
    }

    public class ShowCommentsViewModel
    {
        public int CourseId { get; set; }
        public int CommentId { get; set; }
        public string ImageName { get; set; }
        public string UserName { get; set; }
        public string CommentBody { get; set; }
        public DateTime CreateDate { get; set; }
        public int Reply { get; set; }
        public int Like { get; set; }

    }
    public class ShowCommentReplies
    {
        public string ReplyBody { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ShowCartDetailsViewMode
    {
        public int DetailId { get; set; }
        public int CourseId { get; set; }
        public string CourseImageName { get; set; }
        public string CourseName { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int TotlaPrice { get; set; }
    }

    public class BuyCourseDirectViewModel
    {
        public int Price { get; set; }
    }

    public class ShowOnlineViewModel
    {
        public int EpisodeName { get; set; }
    }

    public class ShowMainGroupsForIndex
    {
        public string MainGtoupTitle { get; set; }
        public string ImageName { get; set; }
        public int MainGroupId { get; set; }
        public int CourseCount { get; set; }
    }

    public class ShowItemsForIndexPage
    {
        public List<ShowMainGroupsForIndex> MainGroups { get; set; }
        public List<ShowCourseViewModel> PopularCourses { get; set; }
        public List<TeachersViewMode> Teachers { get; set; }
    }

    public class TeachersViewMode
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
    public class CourseRateViewModel
    {
        public int UserRate { get; set; }
        public int LikeCount { get; set; }
        public double AverageCourseRate { get; set; }
        public double RateNumbers { get; set; }
        public int Rate1 { get; set; }
        public int Rate2 { get; set; }
        public int Rate3 { get; set; }
        public int Rate4 { get; set; }
        public int Rate5 { get; set; }

    }
}
