using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;

namespace ZabanAmoz.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class MessageController : Controller
    {
        private IUserPanelService _userPanelService;
        
        public MessageController(IUserPanelService userPanelService, IAdminMessageToUserRepository adminMessageToUserRepository)
        {
            _userPanelService = userPanelService;
        }
        public IActionResult Index(int pageId=1)
        {
            Tuple<List<ShowRecievedMessageViewModel>,int> showRecieved =
                _userPanelService.GetRecievedMessage(pageId);
            ViewBag.CurrentPage = pageId;
            return View(showRecieved);
        }

        public IActionResult ShowRecievedMessageBody(int messageId)
        {
            ShowRecievedMessageBodyViewModel showMessage = _userPanelService.
                GetRecievedMessageBody(messageId);

            return View(showMessage);  
        }

        public IActionResult ShowSentMessageBody(int messageId)
        {
            ShowSentMessageBodyViewModel sentMessageBody =
                _userPanelService.GetsentMessageBody(messageId);

            return View(sentMessageBody);
        }

        public IActionResult ShowSendMessages(int pageId=1)
        {
            Tuple<List<ShowSentMessageViewModel>, int> sentMessages =
                _userPanelService.GetSentMessage(pageId);
            ViewBag.CurrentPage = pageId;
            
            return View(sentMessages);
        }

        #region Send Message
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(SendMessageViewModel message)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!_userPanelService.SendMessage(message))
            {
                ModelState.AddModelError("RecieverName", "نام کاریری وارد شده صحیح نمی باشد");
                return View(message);
            }
            ViewBag.sendMessageStatus = true;
            return View();
        }

        public IActionResult ShowAdminMessage(int pageId= 1)
        {
            Tuple<List<AdminMessageViewModel>,int> adminMessages = _userPanelService.GetAdminMessageForUserPanel();
            ViewBag.CurrentPage = pageId;

            return View(adminMessages);
        }


        public IActionResult ShowAdminMessageBody(int messageId)
        {
            AdminMessageBodyViewModel adminMessageBody = 
                _userPanelService.GetAdminMessageBody(messageId);

            return View(adminMessageBody);
        }

        [HttpPost]
        [Route("file-upload")]
        #region CK Editor Upload Images
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();



            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/MyImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }



            var url = $"{"/CkEditorUp/"}{fileName}";


            return Json(new { uploaded = true, url });
        }
        #endregion


        #endregion

    }
}
