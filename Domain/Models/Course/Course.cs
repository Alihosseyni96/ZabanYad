using Domain.Models.Cart;
using Domain.Models.Users;
using Domain.MyEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Course
{
    public class Course
    {
        [Key]

        public int CourseId { get; set; }


        [Display(Name = "عنوان دوره ")]
        [MaxLength(300, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseTitle { get; set; }

        [Display(Name = "توضیح مختصر ")]
        [MaxLength(250, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseDescription { get; set; }

        [Display(Name = "توضیحات دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseText { get; set; }

        [Display(Name = "قیمت دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoursePrice { get; set; }


        [Display(Name = "مدرس  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TeacherId { get; set; }

        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; }


        [Display(Name = "تاریخ شروع دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreateDate { get; set; }

        public int Visit { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "سطح دوره ")]
        public MyEnums.CourseLevel CourseLevel { get; set; }


        [Display(Name = "وضعیت دوره ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public MyEnums.CourseStatus CourseStatus { get; set; }
        public string CourseImageName { get; set; }
        public string CourseDemoName { get; set; }


        #region Relaions

        [ForeignKey("TeacherId")]
        public User User { get; set; }
        public List<CourseToGroup> CourseToGroups { get; set; }
        public List<Episode> Episodes { get; set; }
        public List<Comment.Comment> Comments { get; set; }
        public List<CartDetail> CartDetails { get; set; }
        public List<UserToCourse> UserToCourses { get; set; }
        public List<RateCourse> RateCourses { get; set; }

        #endregion

    }
}
