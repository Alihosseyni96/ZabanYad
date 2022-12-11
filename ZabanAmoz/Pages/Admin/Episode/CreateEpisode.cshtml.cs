using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Domain.Models.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Episode
{
    [RoleChecker(2)]

    public class CreateEpisodeModel : PageModel
    {
        private IEpisodeService _episodeService;
        public CreateEpisodeModel(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [BindProperty]
        public CreateEpisodeViewModel CreateEpisode { get; set; }
        public void OnGet(int courseId)
        {
            ViewData["CourseId"] = courseId;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CourseId"] = CreateEpisode.CourseId;
                return Page();
            }
            _episodeService.AddEpisode(CreateEpisode);
            return Redirect("/Admin/Episode/Index?courseId="+CreateEpisode.CourseId);
        }
    }
}
