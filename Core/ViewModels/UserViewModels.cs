using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class RegisterUserViewModel
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PassWord { get; set; }


        [Display(Name = "تکرار کلمه عبور  ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("PassWord", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassWord { get; set; }


        [Display(Name = "شماره تلفن همراه ")]
        [MaxLength(12, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [MinLength(11, ErrorMessage = "    {0} نمیتواند کمتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

    }

    public class RegisterSuccessViewModel
    {
        public string UserName { get; set; }
        public string ActiveCode { get; set; }
        public string EmailAddress { get; set; }
    }

    public class LoginUserViewModel
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }

    }

    public class ForgetPasswordViewModel
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }

    public class ResetPasswordViewModel
    {
        [Display(Name = "کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PassWord { get; set; }


        [Display(Name = "تکرار کلمه عبور  ")]
        [MaxLength(200, ErrorMessage = "    {0} نمیتواند بیشتر از{1} باشد ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("PassWord", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassWord { get; set; }

    }



}
