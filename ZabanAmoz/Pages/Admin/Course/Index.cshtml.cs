using Core.IServices;
using Core.Security;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Course
{
    [RoleChecker(2)]

    public class IndexModel : PageModel
    {
        private ICourseService _courseService;
        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public string SearchBox { get; set; }
        [BindProperty]
        public int PageId { get; set; }

        public Tuple<List<ShowCourseForAdminViewModel>,int,int> ShowCourse { get; set; }
        public void OnGet(int pageId = 1, string searchBox = "")
        {
            ViewData["SearchBox"] = searchBox;

            ShowCourse = _courseService.GetCourseForShowAdmin(pageId, searchBox);
        }

        public IActionResult OnPost()
        {
            ViewData["SearchBox"] = SearchBox;
            ShowCourse = _courseService.GetCourseForShowAdmin(PageId, SearchBox);

            return Page();
        }

    }
}
