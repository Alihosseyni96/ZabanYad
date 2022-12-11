using Core.ViewModels;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IUserService
    {
        int AddUser(RegisterUserViewModel registerUser,IFormFile userImg);
        bool IsUserNameExist(string userName);
        bool IsEmailExist(string email);
        bool IsActiveCodeExist(string activeCode);
        RegisterSuccessViewModel GetUserForSuccessRegister(int userId);
        bool ActiveAccount(string activeCode);
        void SendEmailToUser(User user, string emailView, string emailtitle);
        bool LoginUser(LoginUserViewModel loginUser);
        void Logout();
        bool ForgetPassword(ForgetPasswordViewModel forgetPassword);
        void ResetPassword(ResetPasswordViewModel resetPassword,string activeCode);



    }
}
