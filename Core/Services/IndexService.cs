using Core.IServices;
using Core.ViewModels;
using Data.Repositories;
using Domain.IRepositories;
using Domain.Models.Course;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class IndexService : IIndexService
    {
        private ICourseRepository _courseRepository;
        private ICourseGroupRepository _courseGroupRepisotiry;
        private IUserRoleRepository _userRoleRepisotiry;
        private IHttpContextAccessor _httpContextAccessor;
        private IRateCourseRepository _rateCourseRepository;
        public IndexService(ICourseRepository courseRepository, ICourseGroupRepository courseGroupRepisotiry,
            IUserRoleRepository userRoleRepisotiry,IHttpContextAccessor httpContextAccessor, IRateCourseRepository rateCourseRepository)
        {
            _courseRepository = courseRepository;
            _courseGroupRepisotiry = courseGroupRepisotiry;
            _userRoleRepisotiry = userRoleRepisotiry;
            _httpContextAccessor = httpContextAccessor;
            _rateCourseRepository = rateCourseRepository;
        }


        public List<ShowCourseViewModel> GetPopularCourses()
        {
            int userId = 0;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                 userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.
                      FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
            }

            List<Course> courses = _courseRepository.Get().Include(c => c.Episodes).
                  Include(c => c.Episodes).OrderByDescending(c => c.Visit).Take(6).ToList();

            #region Sum courseTime
            List<ShowCourseViewModel> list = new List<ShowCourseViewModel>();
            foreach (var course in courses)
            {
                List<TimeSpan> episodesTime = new List<TimeSpan>();
                TimeSpan courseTime = TimeSpan.Zero;

                episodesTime.AddRange(course.Episodes.Where(e => !e.IsDelete).Select(e => e.Time));
                foreach (var episodeTime in episodesTime)
                {
                    courseTime += episodeTime;
                }
                #region GetLike
                bool like = false;
                int likeCount = 0;

                RateCourse courseRate = _rateCourseRepository.Get(r =>
                    r.CourseId == course.CourseId && r.UserId == userId).SingleOrDefault();
                if (courseRate != null)
                {
                    like = courseRate.Like;
                }
                List<RateCourse> courseLike = _rateCourseRepository.Get(r =>
                       r.CourseId == course.CourseId && r.Like == true).ToList();
                if (courseLike != null)
                {
                    likeCount = courseLike.Count();
                }


                #endregion
                #region Get Rate
                double avarageRate = 0;
                double rateCount = 0;
                double totalRates = 0;
                List<RateCourse> rateCourse = _rateCourseRepository.Get(r => r.CourseId == course.CourseId).ToList();
                if (rateCourse.Count() > 0)
                {
                    rateCount = rateCourse.Count(r => r.Rate != 0);
                    totalRates = rateCourse.Sum(e => e.Rate);
                    avarageRate = Math.Round((totalRates / rateCount), 2);
                }
                #endregion

                list.Add(new ShowCourseViewModel()
                {
                    CourseId = course.CourseId,
                    Description = course.CourseDescription,
                    ImageName = course.CourseImageName,
                    Visit = course.Visit,
                    Price = course.CoursePrice,
                    UpdateDate = course.UpdateDate,
                    Sale = 0,
                    CreateDate = course.CreateDate,
                    title = course.CourseTitle,
                    TotalTime = courseTime,
                    IsLike = like,
                    CourseRate = new CourseRateViewModel()
                    {
                        AverageCourseRate = avarageRate,
                        RateNumbers = rateCount,
                        LikeCount = likeCount
                    }

                });
            }

            #endregion

            return list;

        }


        public List<ShowMainGroupsForIndex> GetMainGroups()
        {
            return _courseGroupRepisotiry.Get(g => g.ParenetId == null).
                Include(g=> g.CourseToGroups).Select(g => new ShowMainGroupsForIndex()
            {
                    ImageName = g.MainGroupImage,
                    MainGroupId = g.GroupId,
                MainGtoupTitle = g.GroupTitle,
                CourseCount = g.CourseToGroups.Count(),
            }).ToList();
        }

        public List<TeachersViewMode> GetTeachers()
        {
            return _userRoleRepisotiry.Get(ur => ur.RoleId == 2).Include(ur => ur.User).Select(ur => new TeachersViewMode()
            {
                Email = ur.User.Email,
                PhoneNumber = ur.User.PhoneNumber,
                TeacherId = ur.UserId,
                TeacherName = ur.User.UserName,
                Image = ur.User.ImageName
            }).ToList();
        }


        public ShowItemsForIndexPage GetItemsForIndex()
        {
            return new ShowItemsForIndexPage()
            {
                MainGroups = GetMainGroups(),
                PopularCourses = GetPopularCourses(),
                Teachers = GetTeachers()
            };
        }

        public bool ShowAdminButton()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                u.Type == ClaimTypes.NameIdentifier).Value);

                return _userRoleRepisotiry.Get(ur =>
                ur.UserId == userId).Any(ur => ur.RoleId == 2 || ur.RoleId == 3 || ur.RoleId == 1);

            }
            return false;
        }
    }
}
