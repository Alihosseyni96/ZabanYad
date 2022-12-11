using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Domain.MyEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ZabanAmoz.Pages.Admin.Course
{
    [RoleChecker(2)]
    [RequestSizeLimit(100 * 1024 * 1024)]
    [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
    public class CreateCourseModel : PageModel
    {

        private ICourseService _courseService;
        private ICourseGroupService _courseGroupService;
        public CreateCourseModel(ICourseService courseService, ICourseGroupService courseGroupService)
        {
            _courseService = courseService;
            _courseGroupService = courseGroupService;
        }

        [BindProperty]
        public CreateCourseViewModel CreateCourse { get; set; }
        public List<CourseLevel> CourseLevels { get; set; }
        public List<CourseStatus> CourseStatuses { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public List<ShowCourseGroupsViewModel> Groups { get; set; }

        public void OnGet()
        {
            CourseLevels = GetConstants.GetLevels();
            CourseStatuses = GetConstants.GetStatus();
            Teachers = _courseService.GetTeachersForShow();
            Groups = _courseGroupService.GetAllCourseGroups();
        }

        public IActionResult OnPost(List<int> groupId)
        {
            #region Validation
            if (!ModelState.IsValid )
            {
                CourseLevels = GetConstants.GetLevels();
                CourseStatuses = GetConstants.GetStatus();
                Teachers = _courseService.GetTeachersForShow();
                Groups = _courseGroupService.GetAllCourseGroups();

                return Page();
            }
            #endregion

            CreateCourse.GroupsId = groupId;
            _courseService.AddCourse(CreateCourse);

            return RedirectToPage("Index");
        }
    }
}
