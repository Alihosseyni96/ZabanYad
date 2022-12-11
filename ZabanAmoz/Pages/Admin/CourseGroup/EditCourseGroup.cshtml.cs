using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.CourseGroup
{
    [RoleChecker(2)]

    public class EditCourseGroupModel : PageModel
    {
        private ICourseGroupService _courseGroupService;
        public EditCourseGroupModel(ICourseGroupService courseGroupService)
        {
            _courseGroupService = courseGroupService;
           
        }

        [BindProperty]
        public EditCourseGroupViewModel  EditCourseGroup { get; set; }
        public void OnGet(int mainGroupId)
        {
            EditCourseGroup = _courseGroupService.GetGroupForEdit(mainGroupId);
        }

        public IActionResult OnPost()
        {
            _courseGroupService.EditCourseGroup(EditCourseGroup);
            return RedirectToPage("Index");
        }
    }
}
