using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Episode
{
    [RoleChecker(2)]

    public class IndexModel : PageModel
    {
        private IEpisodeService _episodeService;
        public IndexModel(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        public List<ShowEpisodeViewModel> EpisodeList { get; set; }
        public CourseViewModel Course { get; set; }
        public void OnGet(int courseId)
        {
            EpisodeList = _episodeService.GetCourseEpisode(courseId);
            Course = _episodeService.GetCourse(courseId);
        }
    }
}
