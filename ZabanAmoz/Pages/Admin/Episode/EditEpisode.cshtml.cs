using Core.IServices;
using Core.Security;
using Core.ViewModels;
using Domain.Models.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Episode
{
    [RoleChecker(2)]

    public class EditEpisodeModel : PageModel
    {
        private IEpisodeService _episodeService;
        public EditEpisodeModel(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [BindProperty]
        public EditEpisodeViewModel EditEpisode { get; set; }
        public void OnGet(int episodeId)
        {
            EditEpisode = _episodeService.GetEpisodeForEdit(episodeId);
        }

        public IActionResult OnPost()
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                EditEpisode = _episodeService.GetEpisodeForEdit(EditEpisode.episodeId);
                return Page();
            }

            #endregion
            _episodeService.EditEpisode(EditEpisode);
            return Redirect("/Admin/Episode/Index?courseId=" + EditEpisode.CourseId);
        }
    }
}
