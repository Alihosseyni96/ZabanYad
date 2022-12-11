using Core.IServices;
using Core.Security;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ZarinpalSandbox.Models;

namespace ZabanAmoz.Controllers
{
    [Authorize]
    public class BuyCourseController : Controller
    {
        private IBuyCourseService _buyCourseService;
        public BuyCourseController(IBuyCourseService buyCourseService)
        {
            _buyCourseService = buyCourseService;
        }

        public IActionResult ShowCart()
        {
            Tuple<List<ShowCartDetailsViewMode>, int> details = _buyCourseService.GetCartDetails();
            return View(details);
        }

        public IActionResult AddToCart(int courseId)
        {
            _buyCourseService.AddDetailToCart(courseId);
            return RedirectToAction("ShowCart");
        }

        public IActionResult RemoveDetail(int courseId)
        {
            _buyCourseService.RemoveDetail(courseId);
            return RedirectToAction("ShowCart");
        }

        public IActionResult BuyByWallet()
        {
            long transActionNumber = _buyCourseService.BuyWithWallte();
            return View(transActionNumber);
        }

        public IActionResult BuyCourseDirectly(int amount)
        {
            var response = _buyCourseService.BuyCourseDirectly(amount);
            if (response.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + response.Result.Authority);
            }
            return NotFound();

        }

        public IActionResult FinalBuyCourseDirectly(int id)
        {
            PaymentVerificationResponse response = _buyCourseService.FinalBuyCourse(id);

            if (response.Status == 100)
            {
                ViewBag.PaymentCode = response.RefId;
                ViewBag.SuccessPayment = true;
            }
            return View();
        }


    }
}
