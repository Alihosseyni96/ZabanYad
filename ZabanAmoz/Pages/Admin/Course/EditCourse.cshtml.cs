using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Domain.Models.Course;
using Domain.MyEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Course
{
    [RoleChecker(2)]
    [RequestSizeLimit(100 * 1024 * 1024)]
    [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
    public class EditCourseModel : PageModel
    {
        private ICourseService _courseService;
        private ICourseGroupService _courseGroupService;
        public EditCourseModel(ICourseService courseService, ICourseGroupService courseGroupService)
        {
            _courseService = courseService;
            _courseGroupService = courseGroupService;
        }

        [BindProperty]
        public EditCourseViewModel EditCourse { get; set; }
        public List<CourseLevel> CourseLevels { get; set; }
        public List<CourseStatus> CourseStatuses { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public List<ShowCourseGroupsViewModel> Groups { get; set; }

        public void OnGet(int courseId)
        {
            CourseLevels = GetConstants.GetLevels();
            CourseStatuses = GetConstants.GetStatus();
            Teachers = _courseService.GetTeachersForShow();
            Groups = _courseGroupService.GetAllCourseGroups();
            EditCourse = _courseService.GetCourseForEdit(courseId);
            
        }

        public IActionResult OnPost(List<int> groupId)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                CourseLevels = GetConstants.GetLevels();
                CourseStatuses = GetConstants.GetStatus();
                Teachers = _courseService.GetTeachersForShow();
                Groups = _courseGroupService.GetAllCourseGroups();
                EditCourse = _courseService.GetCourseForEdit(EditCourse.CourseId);
                return Page();
            }
            #endregion

            EditCourse.GroupsId = groupId;
            _courseService.EditCourse(EditCourse);

            return RedirectToPage("Index");
        }

    }
}
