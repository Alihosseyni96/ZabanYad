using Core.IServices;
using Core.ViewModels;
using Domain.MyEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZabanAmoz.Models;

namespace ZabanAmoz.Controllers
{
    public class HomeController : Controller
    {
        private IIndexService _indexService;
        private IRateCourseService _rateCourseService;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IIndexService indexService,IRateCourseService rateCourseService )
        {
            _logger = logger;
            _indexService = indexService;
            _rateCourseService = rateCourseService;
        }

        public IActionResult Index()
        {
            ShowItemsForIndexPage indexItems =
                _indexService.GetItemsForIndex();

            return View(indexItems);
        }
        public IActionResult LikeCourse(int courseId)
        {
            _rateCourseService.LikeCourse(courseId);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
