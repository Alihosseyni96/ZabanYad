using Core.IServices;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using ZarinpalSandbox.Models;

namespace ZabanAmoz.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]

    public class WalletController : Controller
    {
        private IUserPanelService _userPanelService;
        public WalletController(IUserPanelService userPanelService)
        {
            _userPanelService = userPanelService;
        }

        public IActionResult Index()
        {
            ViewBag.Transactions = _userPanelService.GetAllTransaction();
            return View();
        }

        [HttpPost]
        public IActionResult Index(ChargeWalletViewModel chargeWallet)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                ViewBag.Transactions = _userPanelService.GetAllTransaction();
                return View(chargeWallet);
            }

            #endregion
            var response = _userPanelService.ChargeWallet(int.Parse(chargeWallet.Amount));
            if (response.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + response.Result.Authority);
            }
            return NotFound();
        }

        public IActionResult FinalWalletCharge(int id)
        {
            int walletId = id;
            PaymentVerificationResponse response = _userPanelService.FinalChargeWallet(walletId);

            if (response.Status == 100)
            {
                ViewBag.PaymentCode = response.RefId;
                ViewBag.SuccessPayment = true;
            }
            return View();
        }
    }
}
