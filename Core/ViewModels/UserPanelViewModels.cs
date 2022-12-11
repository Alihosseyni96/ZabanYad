using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class UserPanelDetailsViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageName { get; set; }
        public int WalletRest { get; set; }
        public DateTime RegisterDate { get; set; }

    }

    public class UserPanelEditViewModel
    {

        public int UserId { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "شماره همراه ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string ImageName { get; set; }
        public IFormFile NewUserImage { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="کلمه های عبور مغایرت دارند")]
        public string Repassword { get; set; }

    }

    public class ShowRecievedMessageViewModel
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderImageName { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Read { get; set; }
    }

    public class ShowRecievedMessageBodyViewModel
    {
        public int MessageId { get; set; }
        public int RecieverId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderImageName { get; set; }
        public string MessageTitle { get; set; }
        public string MesssageBody { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ShowSentMessageBodyViewModel
    {
        public int MessageId { get; set; }
        public int RecieverId { get; set; }
        public int SenderId { get; set; }
        public string RecieverName { get; set; }
        public string RecieverImageName { get; set; }
        public string MessageTitle { get; set; }
        public string MesssageBody { get; set; }
        public DateTime CreateDate { get; set; }
    }



    public class SendMessageViewModel
    {

        public string SenderName { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Display(Name = "نام کاربری گیرنده")]
        public string RecieverName { get; set; }
        public int TypeId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Display(Name = "موضوع پیام ")]
        public string MessageTitle { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "متن پیام ")]
        public string MessageBody { get; set; }
    }

    public class ShowSentMessageViewModel
    {
        public int MessageId { get; set; }
        public string RecieverName { get; set; }
        public string RecieverImageName { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Read { get; set; }
    }

    public class ShowAllTransaction
    {
        public int Amount { get; set; }
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public bool IsFinal { get; set; }
        public string type { get; set; }
        public DateTime CreateDate { get; set; }
        public long TransactionNumber { get; set; }

    }
    public class ChargeWalletViewModel
    {
        [Display(Name = "مبلغ ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Amount { get; set; }


    }

    public class AdminMessageViewModel
    {
        public int id { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreateDate { get; set; }
        public string SenderRole { get; set; }
        public bool IsRead { get; set; }
    }

    public class AdminMessageBodyViewModel
    {
        public string MesssageTitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreateDate { get; set; }
        public string SenderRole { get; set; }
    }

    public class ShowPurchesedCoursesViewMode
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public string CourseImageName { get; set; }
        public DateTime? UpdateDate { get; set; }
    }


}
