using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Security.Claims;

namespace ZabanAmoz.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserPanelService _userPanelService;
        public HomeController(IUserPanelService userPanelService)
        {
            _userPanelService = userPanelService;
        }

        public IActionResult Index()
        {

            UserPanelDetailsViewModel userPanelDetails =
            _userPanelService.GetUserPanelDetials();
            return View(userPanelDetails);
        }

        public IActionResult EditUserPanelDetails()
        {
            UserPanelEditViewModel userpanelEdit =
                _userPanelService.GetUserDetailsForEdit();

            return View(userpanelEdit);
        }

        [HttpPost]
        public IActionResult EditUserPanelDetails(UserPanelEditViewModel userPanelEdit )
        {
            #region Validations
            if (!ModelState.IsValid)
            {
                UserPanelEditViewModel userpanelEdit = _userPanelService.GetUserDetailsForEdit();
                return View(userpanelEdit);
            }
            if (userPanelEdit.NewUserImage!=null && !FormFileExtensions.IsImage(userPanelEdit.NewUserImage))
            {
                    ModelState.AddModelError("NewUserImage", "فایل انتخاب شده تصویر نمی باشد");
                    UserPanelEditViewModel userpanelEdit = _userPanelService.GetUserDetailsForEdit();
                    return View(userpanelEdit);
            }
            #endregion
            _userPanelService.EditUserDetials(userPanelEdit);

            return Redirect("/Account/Login");
        }

        public IActionResult ShowPurchasedCourses()
        {
            List<ShowPurchesedCoursesViewMode> puechesedCourses =
                _userPanelService.GetPurchasedCourses();
            return View(puechesedCourses);
        }

    }
}
