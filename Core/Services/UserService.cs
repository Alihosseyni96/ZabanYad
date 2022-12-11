using Core.Generators;
using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Core.Convertors;
using Core.Senders;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Core.Security;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IViewRenderService _viewRender;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserRoleRepository _userRoleReposiory;
        public UserService(IUserRepository userRepository, IViewRenderService viewRender,
            IHttpContextAccessor httpContextAccessor, IUserRoleRepository userRoleReposiory)
        {
            _userRepository = userRepository;
            _viewRender = viewRender;
            _httpContextAccessor = httpContextAccessor;
            _userRoleReposiory = userRoleReposiory;
        }

        public bool ActiveAccount(string activeCode)
        {
            User user = _userRepository.GetEntity(u => u.ActiveCode == activeCode);
            if (user == null)
            {
                return false;
            }
            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqeCode();
            _userRepository.UpdateEntity(user);
            return true;
        }


        public void SendEmailToUser(User user, string emailView, string emailtitle)
        {
            string body = _viewRender.RenderToStringAsync(emailView, user);
            SendEmail.Send(user.Email, emailtitle, body);
        }

        public int AddUser(RegisterUserViewModel registerUser, IFormFile userImg)
        {
            #region AddUser
            User user = new User();
            user.UserName = registerUser.UserName;
            user.PhoneNumber = registerUser.PhoneNumber;
            user.ImageName = "default.jpg";
            if (userImg != null)
            {
                user.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(userImg.FileName);
                string saveImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImg", userImg.FileName);
                using(var stream = new FileStream(saveImage, FileMode.Create))
                {
                    userImg.CopyTo(stream);
                }
            }
            user.ActiveCode = NameGenerator.GenerateUniqeCode();
            user.PassWord = PasswordHelper.EncodePasswordMd5(registerUser.PassWord);
            user.Email = registerUser.Email.FixEmail();
            user.RegisterDate = DateTime.Now;
            _userRepository.AddEntity(user);
            //_userRepository.AddUser(user, userImg);

            #endregion
            #region Add Role 
            _userRoleReposiory.AddEntity(new UserRole()
            {
                // 5 is role of normal users
                UserId = user.UserId,
                RoleId = 4
            });
            #endregion
            SendEmailToUser(user, "_activationEmail", "فعالسازی");
            return user.UserId;
        }

        public RegisterSuccessViewModel GetUserForSuccessRegister(int userId)
        {
            User user = _userRepository.GetEntity(u => u.UserId == userId);
            return new RegisterSuccessViewModel()
            {
                UserName = user.UserName,
                EmailAddress = user.Email,
                ActiveCode = user.ActiveCode
            };
        }

        public bool IsEmailExist(string email)
        {
            return _userRepository.IsExist(u => u.Email == email.FixEmail());
        }

        public bool IsUserNameExist(string userName)
        {
            return _userRepository.IsExist(u => u.UserName == userName);
        }

        public bool LoginUser(LoginUserViewModel loginUser)
        {
            bool userExist = _userRepository.IsExist(u => u.UserName == loginUser.UserName &&
            u.PassWord == PasswordHelper.EncodePasswordMd5(loginUser.PassWord) &&
            !u.IsDelete && u.IsActive);

            if (userExist == true)
            {
                #region User LogIn
                User user = _userRepository.GetEntity(u => u.UserName == loginUser.UserName);
                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,loginUser.UserName),
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = loginUser.RememberMe
                };
                _httpContextAccessor.HttpContext.SignInAsync(principal, properties);
                return true;

                #endregion
            }
            return false;


        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults
                .AuthenticationScheme);
        }

        public bool ForgetPassword(ForgetPasswordViewModel forgetPassword)
        {
            User user = _userRepository.GetEntity(u => u.UserName == forgetPassword.UserName && u.Email == FixText.FixEmail(forgetPassword.Email));
            if (user != null)
            {
                SendEmailToUser(user, "_forgetPassword", "بازیابی کلمه عبور");
                return true;
            }
            return false;
        }

        public bool IsActiveCodeExist(string activeCode)
        {
            return _userRepository.IsExist(u => u.ActiveCode == activeCode);
        }

        public void ResetPassword(ResetPasswordViewModel resetPassword, string activeCode)
        {
            User user = _userRepository.GetEntity(u => u.ActiveCode == activeCode);
            user.PassWord = PasswordHelper.EncodePasswordMd5(resetPassword.PassWord);
            user.ActiveCode = NameGenerator.GenerateUniqeCode();
            _userRepository.UpdateEntity(user);
        }
    }
}
