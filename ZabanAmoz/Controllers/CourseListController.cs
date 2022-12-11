using Core.IServices;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ZabanAmoz.Controllers
{
    public class CourseListController : Controller
    {
        private ICourseService _courseService;
        private ICourseGroupService _courseGroupService;
        private IRateCourseService _rateCourseService;

        public CourseListController(ICourseService courseService, 
            ICourseGroupService courseGroupService, IRateCourseService rateCourseService)
        {
            _courseService = courseService;
            _courseGroupService = courseGroupService;
            _rateCourseService = rateCourseService;
        }




        public IActionResult Index(string searchKey = null, List<int> groupIds = null ,
            string orderBy = "all", string price ="all", int take = 4)
        {
            ViewBag.SearchKey = searchKey;
            ViewBag.GroupIds = groupIds;
            ViewBag.OrderBy = orderBy;
            ViewBag.Price = price;
            ViewBag.Groups = _courseGroupService.GetAllGroups();
            Tuple<List<ShowCourseViewModel>,int> courseList = _courseService.
                GetCourseWithFilterToShow(searchKey,groupIds,orderBy,price,take);
            return View(courseList);
        }

        public IActionResult LikeCourse(int courseId , string searchKey = null, List<int> groupIds = null,
            string orderBy = "all", string price = "all", int take = 4)
        {

            _rateCourseService.LikeCourse(courseId);

            return Redirect("/CourseList/Index?searchKey=" + searchKey + "&orderBy=" + orderBy
                + "&price=" + price + "&take=" + take + "&groupIds=" + groupIds);
        }
    }
}
