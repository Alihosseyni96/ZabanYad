using Core.IServices;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Course
{
    [RoleChecker(2)]

    public class ReturnCourseModel : PageModel
    {
        private ICourseService _courseService;
        public ReturnCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult OnGet(int courseId, int pageId = 1, string searchBox = "")
        {

            _courseService.ReturnCourse(courseId);
            return Redirect("/Admin/Course/Index?pageId=" + pageId + "&searchBox=" + searchBox);
        }
    }
}
