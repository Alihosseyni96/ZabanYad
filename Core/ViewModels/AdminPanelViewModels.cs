using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{

    public class CreateCourseGroupViewModel
    {
        [Display(Name = "عنوان دوره ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GroupTitle { get; set; }

        public string SubGroupsTitle { get; set; }

        [Display(Name = "تصویر گروه اصلی  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile MainGroupImage { get; set; }

    }

    public class ShowCourseGroupsViewModel
    {
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        public int? ParentId { get; set; }
        public string MainGroupImageName { get; set; }
    }

    public class EditCourseGroupViewModel
    {
        public int MainGroupId { get; set; }
        [Display(Name = "عنوان دوره ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GroupTitle { get; set; }

        public string SubGroupsTitle { get; set; }
        public IFormFile NewMainGroupImage { get; set; }
        public string previousImageName { get; set; }
    }

    public class ShowUsersForAdminPanelViewModel
    {
        public int UserId { get; set; }
        public string UserImageName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> RolesName { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public int WalletReminded { get; set; }
        public bool IsDelete { get; set; }
    }

    public class CreateUserViewModel
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "تکرار کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }


        [Display(Name = "شماره تلفن همراه ")]
        [MaxLength(50, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }
        public IFormFile UserImage { get; set; }
        public string WalletCharge { get; set; }
        public List<int> RolesId { get; set; }
    }


    public class ShowRolesForAdminPanelViewMode
    {
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
    }

    public class UserForEditAdminViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "شماره تلفن همراه ")]
        [MaxLength(50, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }
        [Display(Name = "کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "تکرار کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }

        public string ImageName { get; set; }
        public IFormFile UserImage { get; set; }
        public int WalletCharge { get; set; }
        public List<int> RolesId { get; set; }
    }

    public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
    public class CreateCourseViewModel
    {
        [Display(Name = "عنوان دوره ")]
        [MaxLength(300, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseTitle { get; set; }

        [Display(Name = "توضیح مختصر  ")]
        [MaxLength(250, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseText { get; set; }

        [Display(Name = "قیمت دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoursePrice { get; set; }


        [Display(Name = "مدرس  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TeacherId { get; set; }



        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "سطح دوره ")]
        public Domain.MyEnums.CourseLevel CourseLevel { get; set; }


        [Display(Name = "وضعیت دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Domain.MyEnums.CourseStatus CourseStatus { get; set; }

        [Display(Name = "تصویر دوره  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile CourseImage { get; set; }
        public IFormFile CourseDemoFile { get; set; }
        public List<int> GroupsId { get; set; }
    }
    public class ShowCourseForAdminViewModel
    {
        public int CourseId { get; set; }
        public string ImageName { get; set; }
        public string Coursetitle { get; set; }
        public List<string> CourseGroups { get; set; }
        public string TeacherName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Domain.MyEnums.CourseStatus CourseStatus { get; set; }
        public Domain.MyEnums.CourseLevel CourseLevel { get; set; }
        public int CoursePrice { get; set; }
        public int EpisodeCount { get; set; }
        public int Visit { get; set; }
        public int SaleCount { get; set; }
        public bool IsDelete { get; set; }

    }

    public class EditCourseViewModel
    {
        public int CourseId { get; set; }

        [Display(Name = "عنوان دوره ")]
        [MaxLength(300, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseTitle { get; set; }

        [Display(Name = "توضیح مختصر  ")]
        [MaxLength(250, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseText { get; set; }

        [Display(Name = "قیمت دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoursePrice { get; set; }


        [Display(Name = "مدرس  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TeacherId { get; set; }



        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "سطح دوره ")]
        public Domain.MyEnums.CourseLevel CourseLevel { get; set; }


        [Display(Name = "وضعیت دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Domain.MyEnums.CourseStatus CourseStatus { get; set; }

        [Display(Name = "تصویر دوره  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseImageName { get; set; }
        public string DemoFileName { get; set; }
        public IFormFile NewDemoFile { get; set; }
        public IFormFile NewCourseImage { get; set; }
        public List<int> GroupsId { get; set; }

    }
    public class CreateAdminMessageViewModel
    {
        [Display(Name = "عنوان پیام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        public string MessageTitle { get; set; }


        [Display(Name = "متن پیام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MessageBody { get; set; }

        public List<int> RecieverRoles { get; set; }
    }

    public class ShowAdminMessageViewModel
    {
        public int AdminMessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderRoles { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public string ReceiverGroups { get; set; }
    }

    public class ShowAdminMessageBodyViewModel
    {
        public string Messagetitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreateDate { get; set; }
        public string SenderName { get; set; }
        public string ReceiverGroups { get; set; }
    }

    public class ShowEpisodeViewModel
    {
        public int EpisodeId { get; set; }
        public string EpisodeTitle { get; set; }
        public string CourseName { get; set; }
        public bool IsFree { get; set; }
        public TimeSpan EpisodeTime { get; set; }
    }

    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class CreateEpisodeViewModel
    {

        public int CourseId { get; set; }


        [Display(Name = "مدت زمان قسمت ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression("[0-9][0-9]:[0-9][0-9]:[0-9][0-9]",ErrorMessage ="مشابه الگو (00:00:00) وارد کنید")]
        public string EpisodeTime { get; set; }


        [Display(Name = "وضعیت قسمت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsFree { get; set; }


        [Display(Name = "فایل قسمت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile EpisodeFile { get; set; }


        [Display(Name = "عنوان قسمت ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EpissodeTitle { get; set; }
    }

    public class EditEpisodeViewModel
    {
        public int episodeId { get; set; }
        public int CourseId { get; set; }



        [Display(Name = "مدت زمان قسمت ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression("[0-9][0-9]:[0-9][0-9]:[0-9][0-9]", ErrorMessage = "مشابه الگو (00:00:00) وارد کنید")]
        public string EpisodeTime { get; set; }


        [Display(Name = "وضعیت قسمت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsFree { get; set; }


        [Display(Name = "عنوان قسمت ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EpissodeTitle { get; set; }

        public string EpisodeFileName { get; set; }

        public IFormFile NewEpisodeFile { get; set; }

    }

    public class ShowCommentsForAdminViewModel
    {
        public int Replyies { get; set; }
        public int CommentId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public bool Show { get; set; }
    }

    public class CommentBodyViewModel
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string ImageName { get; set; }
        public int Replies { get; set; }
        public string BodyText { get; set; }
        public DateTime CreateDate { get; set; }

    }

    public class ReplyCommentsBody
    {
        public string UserName { get; set; }
        public string ImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public int ReplyId { get; set; }
        public string ReplyBody { get; set; }
    }

    public class AdminDashboardViewModel
    {
        public int CourseCount { get; set; }
        public int UserCount { get; set; }
        public int Comments { get; set; }
        public int NotShownComment { get; set; }
        public int CoursesVisit { get; set; }
    }
    public class SiteRateViewModel
    {
        public double Rate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
