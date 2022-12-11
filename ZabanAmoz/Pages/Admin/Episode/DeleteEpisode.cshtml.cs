using Core.IServices;
using Core.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZabanAmoz.Pages.Admin.Episode
{
    [RoleChecker(2)]

    public class DeleteEpisodeModel : PageModel
    {
        private IEpisodeService _episodeService;
        public DeleteEpisodeModel(IEpisodeService episodeService )
        {
            _episodeService = episodeService;
        }
        public IActionResult OnGet(int episodeId , int courseId)
        {
            _episodeService.DeleteEpisode(episodeId);
            return Redirect("/Admin/Episode/Index?courseId=" + courseId);
        }
    }
}
