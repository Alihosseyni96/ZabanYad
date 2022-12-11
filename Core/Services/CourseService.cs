using Core.Convertors;
using Core.Generators;
using Core.IServices;
using Core.ViewModels;
using Data.Repositories;
using Domain.IRepositories;
using Domain.Models.Course;
using Domain.Models.Users;
using Domain.MyEnums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CourseService : ICourseService
    {
        private IUserRoleRepository _userRoleRepository;
        private ICourseRepository _courseRepository;
        private ICourseToGroupRepository _courseToGroupRepository;
        private IHttpContextAccessor _httpContextAcessor;
        private IUserRepository _userRepository;
        private IEpisodeRepository _episodeRepository;
        private IUserToCourseRepository _userToCourseRepository;
        private IRateCourseRepository _rateCourseRepository;
        public CourseService(IUserRoleRepository userRoleRepository, ICourseRepository courseRepository,
            ICourseToGroupRepository courseToGroupRepository, IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,IEpisodeRepository episodeRepository,
            IUserToCourseRepository userToCourseRepository, IRateCourseRepository rateCourseRepository)
        {
            _userRoleRepository = userRoleRepository;
            _courseRepository = courseRepository;
            _courseToGroupRepository = courseToGroupRepository;
            _httpContextAcessor = httpContextAccessor;
            _userRepository = userRepository;
            _episodeRepository = episodeRepository;
            _userToCourseRepository = userToCourseRepository;
            _rateCourseRepository = rateCourseRepository;
        }

        public void AddCourse(CreateCourseViewModel createCourse)
        {
            #region Add Course
            Course course = new Course()
            {
                CourseImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(createCourse.CourseImage.FileName),
                CourseLevel = createCourse.CourseLevel,
                CoursePrice = createCourse.CoursePrice,
                CourseStatus = createCourse.CourseStatus,
                CourseText = createCourse.CourseText,
                CourseTitle = createCourse.CourseTitle,
                CourseDescription = createCourse.ShortDescription,
                CreateDate = DateTime.Now,
                IsDelete = false,
                TeacherId = createCourse.TeacherId,
                Visit = 0,
                UpdateDate = null,

            };
            if (createCourse.CourseDemoFile != null)
                course.CourseDemoName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(createCourse.CourseDemoFile.FileName);


            _courseRepository.AddEntity(course);

            #endregion

            #region Add Groups
            foreach (var groupId in createCourse.GroupsId)
            {
                _courseToGroupRepository.AddEntity(new Domain.Models.Course.CourseToGroup()
                {
                    CourseId = course.CourseId,
                    CourseGroupId = groupId
                });
            }

            #endregion

            #region Save CourseImage in 2 Size
            string saveOrginalImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImage/OrginalImg", course.CourseImageName);
            string saveFingerImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImage/FingerImg", course.CourseImageName);
            using (var stream = new FileStream(saveOrginalImagePath, FileMode.Create))
            {
                createCourse.CourseImage.CopyTo(stream);
            }
            //save finger Image
            ResizeImage.Image_resize(saveOrginalImagePath, saveFingerImagePath, 250);
            #endregion

            #region Save Course Demo
            if (createCourse.CourseDemoFile != null)
            {
                string saveDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseDemo", course.CourseDemoName);
                using (var stream = new FileStream(saveDemoPath, FileMode.Create))
                {
                    createCourse.CourseDemoFile.CopyTo(stream);
                }

            }
            #endregion
        }

        public void DeleteCourse(int courseId)
        {
            Course course = _courseRepository.Get(c => c.CourseId == courseId).Single();
            course.IsDelete = true;
            _courseRepository.UpdateEntity(course);

        }

        public void EditCourse(EditCourseViewModel editCourse)
        {
            Course course = _courseRepository.Get(c => c.CourseId == editCourse.CourseId).Single();
            course.CourseId = editCourse.CourseId;
            course.CourseTitle = editCourse.CourseTitle;
            course.CourseLevel = editCourse.CourseLevel;
            course.CoursePrice = editCourse.CoursePrice;
            course.CourseStatus = editCourse.CourseStatus;
            course.CourseText = editCourse.CourseText;
            course.TeacherId = editCourse.TeacherId;
            course.CourseDescription = editCourse.ShortDescription;
            course.CourseImageName = editCourse.CourseImageName;
            course.CourseDemoName = editCourse.DemoFileName;

            #region Save New Image
            if (editCourse.NewCourseImage != null)
            {
                //delete previous image (orginal and finger)
                string deleteFingerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImage/FingerImg", editCourse.CourseImageName);
                string deleteOrginalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImage/OrginalImg", editCourse.CourseImageName);
                System.IO.File.Delete(deleteFingerPath);
                System.IO.File.Delete(deleteOrginalPath);

                //save new images (orginal and finger )
                course.CourseImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(editCourse.NewCourseImage.FileName);
                string saveNewFingerImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImage/FingerImg", course.CourseImageName);
                string saveNewOrginalImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImage/OrginalImg", course.CourseImageName);
                using (var steam = new FileStream(saveNewOrginalImage, FileMode.Create))
                {
                    editCourse.NewCourseImage.CopyTo(steam);
                }
                ResizeImage.Image_resize(saveNewOrginalImage, saveNewFingerImage, 150);
            }
            #endregion

            #region Save New Demo
            if (editCourse.NewDemoFile != null)
            {
                //If The Course Had Demo Befor: Delete It
                if (editCourse.DemoFileName != null)
                {
                    string deleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseDemo", editCourse.DemoFileName);
                    System.IO.File.Delete(deleteDemoPath);
                }
                course.CourseDemoName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(editCourse.NewDemoFile.FileName);
                string saveNewDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseDemo", course.CourseDemoName);
                using (var stream = new FileStream(saveNewDemoPath, FileMode.Create))
                {
                    editCourse.NewDemoFile.CopyTo(stream);
                }

            }

            #endregion

            _courseRepository.UpdateEntity(course);

            #region Delete Previous Groups and add New Ones
            List<CourseToGroup> courseToGroups = _courseToGroupRepository.Get(cg => cg.CourseId == editCourse.CourseId).ToList();
            foreach (var item in courseToGroups)
            {
                _courseToGroupRepository.Delete(item);
            }
            foreach (var groupId in editCourse.GroupsId)
            {
                _courseToGroupRepository.AddEntity(new CourseToGroup()
                {
                    CourseId = editCourse.CourseId,
                    CourseGroupId = groupId
                });
            }

            #endregion
        }

        public EditCourseViewModel GetCourseForEdit(int courseId)
        {
            return _courseRepository.Get(c => c.CourseId == courseId).Include(c => c.User).Include(c => c.CourseToGroups).
                Select(c => new EditCourseViewModel()
                {
                    CourseImageName = c.CourseImageName,
                    CourseText = c.CourseText,
                    CoursePrice = c.CoursePrice,
                    TeacherId = c.User.UserId,
                    CourseLevel = c.CourseLevel,
                    ShortDescription = c.CourseDescription,
                    CourseStatus = c.CourseStatus,
                    CourseTitle = c.CourseTitle,
                    GroupsId = c.CourseToGroups.Select(cg => cg.CourseGroupId).ToList(),
                    CourseId = c.CourseId,
                    DemoFileName = c.CourseDemoName
                }).Single();
        }

        public Tuple<List<ShowCourseForAdminViewModel>, int, int> GetCourseForShowAdmin(int pageId = 1, string searchBox = "")
        {
            List<ShowCourseForAdminViewModel> courseList = new List<ShowCourseForAdminViewModel>();
            int take;
            int skip;
            int totalNumberOfUsers;
            int pageNumbers;

            if (searchBox != null)
            {
                #region Paging
                take = 4;
                skip = (pageId - 1) * take;
                totalNumberOfUsers = _courseRepository.Get(u => u.CourseTitle.Contains(searchBox) ||
                                        u.CourseToGroups.Select(c => c.CourseGroup.GroupTitle).Contains(searchBox)).Count();
                if (pageId != 1 && totalNumberOfUsers <= take)
                {
                    skip = 0;
                    pageId = 1;
                }
                pageNumbers = totalNumberOfUsers / take;
                if (totalNumberOfUsers % take != 0)
                {
                    pageNumbers = pageNumbers + 1;
                }


                #endregion
                #region Get User With Search Filter
                courseList = _courseRepository.Get(c => c.CourseTitle.Contains(searchBox) ||
                c.CourseToGroups.Select(cg => cg.CourseGroup.GroupTitle).Contains(searchBox) ||
                c.User.UserName.Contains(searchBox)).Include(c=> c.Episodes).Include(c => c.User).
                Include(c => c.CourseToGroups).ThenInclude(cg => cg.CourseGroup).
                Select(c => new ShowCourseForAdminViewModel()
                {
                    EpisodeCount = c.Episodes.Count(),
                    CourseId = c.CourseId,
                    CourseLevel = c.CourseLevel,
                    CoursePrice = c.CoursePrice,
                    CourseStatus = c.CourseStatus,
                    Coursetitle = c.CourseTitle,
                    CreateDate = c.CreateDate,
                    ImageName = c.CourseImageName,
                    TeacherName = c.User.UserName,
                    UpdateDate = c.UpdateDate,
                    Visit = c.Visit,
                    IsDelete = c.IsDelete,
                    CourseGroups = (List<string>)c.CourseToGroups.Select(cg => cg.CourseGroup.GroupTitle),

                }).Skip(skip).Take(take).ToList();
                return Tuple.Create(courseList, pageNumbers, pageId);

                #endregion
            }
            #region Paging
            take = 4;
            skip = (pageId - 1) * take;
            totalNumberOfUsers = _courseRepository.Get().Count();
            pageNumbers = totalNumberOfUsers / take;
            if (totalNumberOfUsers % take != 0)
            {
                pageNumbers = pageNumbers + 1;
            }

            #endregion

            #region Get User Without Search Filter
            courseList = _courseRepository.Get().Include(c => c.User).Include(c => c.CourseToGroups).
    Select(c => new ShowCourseForAdminViewModel()
    {
        CourseId = c.CourseId,
        CourseLevel = c.CourseLevel,
        CoursePrice = c.CoursePrice,
        CourseStatus = c.CourseStatus,
        Coursetitle = c.CourseTitle,
        CreateDate = c.CreateDate,
        ImageName = c.CourseImageName,
        TeacherName = c.User.UserName,
        UpdateDate = c.UpdateDate,
        Visit = c.Visit,
        IsDelete = c.IsDelete,
        CourseGroups = (List<string>)c.CourseToGroups.Select(cg => cg.CourseGroup.GroupTitle),

    }).Skip(skip).Take(take).ToList();
            return Tuple.Create(courseList, pageNumbers, pageId);
            #endregion

        }

        public ShowCourseDetialsViewModel GetCourseToShow(int courseId)
        {
            #region Authenticated User Info
            string authenticatedUserName = "";
            string authenricatedUserImageName = "";
            bool userIsAuthenricated = false;
            bool userPerchesedCourse = false;
            int userId;
            if (_httpContextAcessor.HttpContext.User.Identity.IsAuthenticated)
            {
                 userId = int.Parse(_httpContextAcessor.HttpContext.User.Claims.
                   FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);

                userPerchesedCourse = _userToCourseRepository.Get(uc =>
                  uc.CourseId == courseId && uc.UserId == userId).Any();

                userIsAuthenricated = true;
                authenticatedUserName = _httpContextAcessor.HttpContext.User.Identity.Name;
                authenricatedUserImageName = _userRepository.Get(u =>
               u.UserName == authenticatedUserName).Single().ImageName;
            }

            #endregion

            #region Sum EpisodeTimes
            List<Episode> episodes = _episodeRepository.Get(e => e.CourseId == courseId && !e.IsDelete).ToList();
            TimeSpan courseTime = TimeSpan.Zero;
            if (episodes.Count() > 0 )
            {
                List<TimeSpan> episodesTime = episodes.Select(e => e.Time).ToList();

                foreach (var episodeTime in episodesTime)
                {
                    courseTime += episodeTime;

                }

            }


            #endregion
            #region Increase Visit
            Course course = _courseRepository.Get(c => c.CourseId == courseId).Single();
            course.Visit += 1;
            _courseRepository.UpdateEntity(course);
            #endregion
            return _courseRepository.Get(c => c.CourseId == courseId).Include(c => c.Episodes).
                Include(c => c.User).Select(c => new ShowCourseDetialsViewModel()
                {
                    Episodes = c.Episodes.Where(e=> !e.IsDelete).Select(e=> new EpisodeViewModel()
                    {
                        EpisodeId = e.EpisodeId,
                        EpisodeTime = e.Time,
                        EpisodeTitle = e.Title,
                        IsFree = e.IsFree,
                        EpisodeFileName = e.FileName,
                    }  ).ToList(),
                    UserIdAuthenticated = userIsAuthenricated,
                    UserPuechesedCourse = userPerchesedCourse,
                    CourseId = c.CourseId,
                    CourseLevel = c.CourseLevel,
                    CoursePrice = c.CoursePrice,
                    CourseStatus = c.CourseStatus,
                    CourseText = c.CourseText,
                    CourseTitle = c.CourseTitle,
                    CreateDate = c.CreateDate,
                    CourseTime = courseTime,
                    DemoFileName = c.CourseDemoName,
                    ImageName = c.CourseImageName,
                    LastUpdate = c.UpdateDate,
                    TeacherName = c.User.UserName,
                    AuthenticatedUserImageName = authenricatedUserImageName,
                    AuthenticatedUserName = authenticatedUserName
                }).Single();
        }



        public Tuple<List<ShowCourseViewModel>,int> GetCourseWithFilterToShow(string searchKey = null, List<int> groupIds = null,
            string orderBy = "all", string price ="all" ,int take = 5)
        {
            int userId = 0;
            if (_httpContextAcessor.HttpContext.User.Identity.IsAuthenticated)
            {
                 userId = int.Parse(_httpContextAcessor.HttpContext.User.Claims.
                 FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);

            }
            List<Course> courses = _courseRepository.Get().Include(c => c.Episodes).
                Include(c => c.Episodes).ToList();
            #region Filters
            if (groupIds.Count != 0)
            {
                List<int> courseIds = _courseToGroupRepository.Get(cg =>
                groupIds.Contains(cg.CourseGroupId)).Select(cg => cg.CourseId).ToList();
                courses = _courseRepository.Get(c => courseIds.Contains(c.CourseId)).ToList();
            }
            if (searchKey != null)
            {
                courses = courses.Where(c => c.CourseTitle.Contains(searchKey) ||
                c.CourseDescription.Contains(searchKey)).ToList();
            }

            switch (price)
            {

                case "free":
                    {
                        courses = courses.Where(c => c.CoursePrice == 0).ToList();
                        break;
                    }
                case "NoFree":
                    {
                        courses = courses.Where(c => c.CoursePrice != 0).ToList();
                        break;
                    }
            }


            switch (orderBy)
            {
                case "all":
                    {
                        courses = courses.OrderByDescending(c => c.CreateDate).ToList();
                        break;
                    }
                case "visit":
                    {
                        courses = courses.OrderByDescending(c => c.Visit).ToList();
                        break;
                    }
                case "updateDate":
                    {
                        courses = courses.OrderByDescending(c => c.UpdateDate).ToList();
                        break;
                    }


            }

            #endregion

            #region Sum courseTime
            List<ShowCourseViewModel> list = new List<ShowCourseViewModel>();
            foreach (var course in courses)
            {
                List<TimeSpan> episodesTime = new List<TimeSpan>();
                TimeSpan courseTime = TimeSpan.Zero;

                episodesTime.AddRange(course.Episodes.Where(e=> !e.IsDelete).Select(e => e.Time));
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
                if (courseLike!=null)
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
                        LikeCount = likeCount,
                    }
                });
            }

            #endregion

            return Tuple.Create(list.Take(take).ToList(), list.Count());

        }

        public List<ShowCourseViewModel> GetPopularCourses()
        {
            List<Course> courses = _courseRepository.Get().Include(c => c.Episodes).
                  Include(c => c.Episodes).OrderByDescending(c=> c.Visit).Take(6).ToList();

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
                });
            }

            #endregion

            return list;

        }

        public List<TeacherViewModel> GetTeachersForShow()
        {
            return _userRoleRepository.Get(ur => ur.RoleId == 2).Include(ur => ur.User).Select(u => new TeacherViewModel()
            {
                TeacherId = u.User.UserId,
                TeacherName = u.User.UserName
            }).ToList();
        }

        public void ReturnCourse(int courseId)
        {
            Course course = _courseRepository.Get(c => c.CourseId == courseId).Single();
            course.IsDelete = false;
            _courseRepository.UpdateEntity(course);
        }
    }
}

