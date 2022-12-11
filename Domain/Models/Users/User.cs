using Domain.Models.AdminMessage;
using Domain.Models.Cart;
using Domain.Models.Comment;
using Domain.Models.Course;
using Domain.Models.Wallet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }


        [Display(Name = "کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PassWord { get; set; }


        [Display(Name = "شماره تلفن همراه ")]
        [MaxLength(50, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }


        [Display(Name = "تصویر")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        public string ImageName { get; set; }


        [Display(Name = "تاریخ عضویت ")]
        public DateTime RegisterDate { get; set; }


        [Display(Name = "کد فعالسازی ")]
        public string ActiveCode { get; set; }

        public bool IsActive { get; set; }


        [Display(Name = "حذف شده ")]
        public bool IsDelete { get; set; }

        #region Relations


        [InverseProperty("Receiver")]
        public List<Message> MessageToReceiver { get; set; }

        [InverseProperty("Sender")]
        public List<Message> MessageToSender { get; set; }

        public List<Wallet.Wallet> Wallets { get; set; }
        public List<Course.Course> Courses { get; set; }

        public List<UserRole> UserRoles { get; set; }
        public List<AdminMessage.AdminMessage> AdminMessages { get; set; }
        public List<AdminMessageToUser> AdminMessageToUsers { get; set; }
        public List<Comment.Comment> Comments { get; set; }
        public List<ReplyComment> ReplyComments { get; set; }
        public List<Cart.Cart> Carts { get; set; }
        public List<UserToCourse> UserToCourses { get; set; }
        public List<DirectBuy> DirectBuys { get; set; }
        public List<RateCourse> RateCourses { get; set; }

        #endregion

    }
}
