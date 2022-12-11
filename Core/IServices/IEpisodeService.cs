using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IEpisodeService
    {
        List<ShowEpisodeViewModel> GetCourseEpisode(int courseId);
        CourseViewModel GetCourse(int courseId);
        void AddEpisode(CreateEpisodeViewModel episode);

        void DeleteEpisode(int episdeId);

        EditEpisodeViewModel GetEpisodeForEdit(int episodeId);

        void EditEpisode(EditEpisodeViewModel editEpisode);
    }
}
