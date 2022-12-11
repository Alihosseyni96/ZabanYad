using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace ZabanAmoz.Pages.Admin.CourseGroup
{
    [RoleChecker(2)]

    public class CreateGroupModel : PageModel
    {
        private ICourseGroupService _courseGroupService;
        public CreateGroupModel(ICourseGroupService courseGroupService)
        {
            _courseGroupService = courseGroupService;
        }

        [BindProperty]
        public CreateCourseGroupViewModel CreateCourseGroup { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _courseGroupService.AddCourseGroup(CreateCourseGroup);
            return RedirectToPage("Index");
        }

    }
}
