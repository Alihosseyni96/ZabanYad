using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.CourseGroup
{
    [RoleChecker(2)]

    public class IndexModel : PageModel
    {
        private ICourseGroupService _courseGroupService;
        public IndexModel(ICourseGroupService courseGroupService)
        {
            _courseGroupService = courseGroupService;
        }

        public List<ShowCourseGroupsViewModel> CourseGroups { get; set; }
        public void OnGet()
        {
            CourseGroups = _courseGroupService.GetAllCourseGroups();
        }
    }
}
