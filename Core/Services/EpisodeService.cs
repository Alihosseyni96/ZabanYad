using Core.Generators;
using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Domain.Models.Course;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EpisodeService:IEpisodeService
    {
        private IEpisodeRepository _episodeRepository;
        private ICourseRepository _courseRepository;

        public EpisodeService(IEpisodeRepository episodeRepository, ICourseRepository courseRepository )
        {
            _episodeRepository = episodeRepository;
            _courseRepository = courseRepository;
        }

        public List<ShowEpisodeViewModel> GetCourseEpisode(int courseId)
        {
            return _episodeRepository.Get(e => e.CourseId == courseId && !e.IsDelete).Select(e => new ShowEpisodeViewModel()
            {
                EpisodeId = e.EpisodeId,
                EpisodeTime = e.Time,
                EpisodeTitle = e.Title,
                IsFree = e.IsFree,
            }).ToList();
        }

        public CourseViewModel GetCourse(int courseId)
        {
            return _courseRepository.Get(c => c.CourseId == courseId).Select(c => new CourseViewModel()
            {
                CourseId = c.CourseId,
                CourseName = c.CourseTitle,
            }).Single();
        }

        public void AddEpisode(CreateEpisodeViewModel episode)
        {
            #region Add Episode
            Episode newEpisode = new Episode()
            {
                CourseId = episode.CourseId,
                FileName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(episode.EpisodeFile.FileName),
                IsDelete = false,
                IsFree = episode.IsFree,
                Time = TimeSpan.Parse(episode.EpisodeTime),
                Title = episode.EpissodeTitle
            };
            _episodeRepository.AddEntity(newEpisode);


            #endregion
            #region Update Time of Course
            Course course = _courseRepository.Get(c => c.CourseId == episode.CourseId).Single();
            course.UpdateDate = DateTime.Now;
            _courseRepository.UpdateEntity(course);

            #endregion
            #region Add File Episode
            string episodeFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/CourseEpisode", newEpisode.FileName);

            using (var stream = new FileStream(episodeFilePath, FileMode.Create))
            {
                episode.EpisodeFile.CopyTo(stream);
            }
            #endregion

        }

        public void DeleteEpisode(int episdeId)
        {
            Episode episode = _episodeRepository.Get(e => e.EpisodeId == episdeId).Single();
            episode.IsDelete = true;
            _episodeRepository.UpdateEntity(episode);
        }

        public EditEpisodeViewModel GetEpisodeForEdit(int episodeId)
        {
            Episode episode = _episodeRepository.Get(e => e.EpisodeId == episodeId).Single();

            EditEpisodeViewModel editEpisode = new EditEpisodeViewModel()
            {
                CourseId = episode.CourseId,
                EpisodeFileName = episode.FileName,
                episodeId = episode.EpisodeId,
                EpissodeTitle = episode.Title,
                IsFree = episode.IsFree,
                EpisodeTime = episode.Time.ToString()
            };
            return editEpisode;

        }

        public void EditEpisode(EditEpisodeViewModel editEpisode)
        {
            Episode episode = _episodeRepository.Get(e => e.EpisodeId == editEpisode.episodeId).SingleOrDefault();
            episode.Title = editEpisode.EpissodeTitle;
            episode.EpisodeId = editEpisode.episodeId;
            episode.CourseId = editEpisode.CourseId;
            episode.IsDelete = false;
            episode.IsFree = editEpisode.IsFree;
            episode.FileName = editEpisode.EpisodeFileName;
            episode.Time = TimeSpan.Parse(editEpisode.EpisodeTime);
            if (editEpisode.NewEpisodeFile!=null)
            {
                #region Remove previous Episode
                string previousFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot/CourseEpisode", episode.FileName);

                System.IO.File.Delete(previousFilePath);

                #endregion

                #region Save New Episode

                episode.FileName = NameGenerator.GenerateUniqeCode() +
                  Path.GetExtension(editEpisode.NewEpisodeFile.FileName);

                string newFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/CourseEpisode", episode.FileName);

                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    editEpisode.NewEpisodeFile.CopyTo(stream);
                }
                #endregion

            }
            _episodeRepository.UpdateEntity(episode);
        }
    }
}
