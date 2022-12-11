using Core.Convertors;
using Core.IServices;
using Core.Senders;
using Core.ViewModels;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace ZabanAmoz.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IViewRenderService _renderView;
        public AccountController(IUserService userService, IViewRenderService renderView)
        {
            _userService = userService;
            _renderView = renderView;
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel registerUser, IFormFile userImg)
        {

            #region Register Validations
            if (!ModelState.IsValid)
            {
                return View(registerUser);
            }
            if (_userService.IsUserNameExist(registerUser.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return View(registerUser);
            }
            if (registerUser.PassWord != registerUser.RePassWord)
            {
                ModelState.AddModelError("PassWord", "کلمه های عبور مغایرت دارند");
                return View(registerUser);

            }
            if (_userService.IsEmailExist(registerUser.Email))
            {
                ModelState.AddModelError("Email", "ایمیل  معتبر نمی باشد");
                return View(registerUser);
            }

            #endregion

            int userId = _userService.AddUser(registerUser, userImg);
            return Redirect("/Account/RegisterSuccess?userId=" + userId);
        }

        public IActionResult RegisterSuccess(int userId)
        {
            RegisterSuccessViewModel registerSuccess =
                _userService.GetUserForSuccessRegister(userId);

            return View(registerSuccess);
        }

        public IActionResult ActiveAccount(string id)
        {
            if (_userService.ActiveAccount(id) != true)
            {
                ViewBag.ActiveResult = false;
            }
            return View();
        }


        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel loginUser)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                return View(loginUser);
            }
            ViewBag.LoginStatus = false;

            #endregion
            if (_userService.LoginUser(loginUser))
            {
                ViewBag.LoginStatus = true;
            }
            return View();
        }

        #endregion

        #region Logout
        public IActionResult Logout()
        {
            _userService.Logout();
            return Redirect("/Home/Index");
        }
        #endregion

        #region Forget Password
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(ForgetPasswordViewModel forgetPassword)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                return View(forgetPassword);
            }

            if (_userService.ForgetPassword(forgetPassword) != true)
            {
                ModelState.AddModelError("UserName", "کاربری یافت نشد");
                return View(forgetPassword);
            }
            #endregion
            ViewBag.ForgetPassword = true;
            return View();
        }

        #endregion

        #region ResetPassword
        public IActionResult ResetPassword(string id)
        {
            if (!_userService.IsActiveCodeExist(id))
            {
                return NotFound();
            }
            ViewBag.ActiveCode = id;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPassword,
            string activeCode)
        {
            #region Validations
            if (!ModelState.IsValid)
            {
                ViewBag.ActiveCode = activeCode;
                return View(resetPassword);
            }
            #endregion
            _userService.ResetPassword(resetPassword, activeCode);
            ViewBag.ResetPasswordStatus = true;
            return View();
        }

        #endregion

    }
}
