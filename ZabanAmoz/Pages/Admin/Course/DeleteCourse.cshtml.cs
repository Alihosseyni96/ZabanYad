using Core.IServices;
using Core.Security;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Course
{
    [RoleChecker(2)]

    public class DeleteCourseModel : PageModel
    {
        private ICourseService _courseService;
        public DeleteCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult OnGet(int courseId, int pageId = 1, string searchBox = null)
        {
            _courseService.DeleteCourse(courseId);
            return Redirect("/Admin/Course/Index?pageId=" + pageId + "&searchBox=" + searchBox);

        }
    }
}
