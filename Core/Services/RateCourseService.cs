using Core.IServices;
using Core.ViewModels;
using Domain.IRepositories;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RateCourseService : IRateCourseService
    {
        private IRateCourseRepository _rateCourseRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public RateCourseService(IRateCourseRepository rateCourseRepository, IHttpContextAccessor httpContextAccessor)
        {
            _rateCourseRepository = rateCourseRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public CourseRateViewModel GetCourseRate(int courseId)
        {
            int userId = 0;
            int userPoint = 0;
            double averagePoint = 0;
            int point1 = 0;
            int point2 = 0;
            int point3 = 0;
            int point4 = 0;
            int point5 = 0;
            double rateNumbers = 0;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                 userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                u.Type == ClaimTypes.NameIdentifier).Value);

            }
            IQueryable<RateCourse> courseRate = _rateCourseRepository.Get(r => r.CourseId == courseId);
            RateCourse userRate = courseRate.Where(r => r.UserId == userId).SingleOrDefault();
            if (userRate!=null)
            {
                userPoint = userRate.Rate;
            }
            if (courseRate!=null)
            {
                rateNumbers = courseRate.Count(r=> r.Rate!=0);
                double totalPoints = courseRate.Sum(r => r.Rate);
                averagePoint = Math.Round((totalPoints / rateNumbers),2);
            }
            
            #region Count of Each Points
            if (courseRate.Any(r => r.Rate == 1))
            {
                point1 = courseRate.Count(r => r.Rate == 1);
            }
            if (courseRate.Any(r => r.Rate == 2))
            {
                point2 = courseRate.Count(r => r.Rate == 2);
            }
            if (courseRate.Any(r => r.Rate == 3))
            {
                point3 = courseRate.Count(r => r.Rate == 3);
            }
            if (courseRate.Any(r => r.Rate == 4))
            {
                point4 = courseRate.Count(r => r.Rate == 4);
            }
            if (courseRate.Any(r => r.Rate == 5))
            {
                point5 = courseRate.Count(r => r.Rate == 5);
            }

            #endregion

            return new CourseRateViewModel()
            {
                UserRate = userPoint,
                AverageCourseRate = averagePoint,
                RateNumbers = rateNumbers,
                Rate1 = point1,
                Rate2 = point2,
                Rate3 = point3,
                Rate4 = point4,
                Rate5 = point5
            };
        }

        public void LikeCourse(int courseId)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
            u.Type == ClaimTypes.NameIdentifier).Value);

            RateCourse rate = _rateCourseRepository.Get(r => r.UserId == userId && r.CourseId == courseId).SingleOrDefault();
            if (rate == null)
            {
                _rateCourseRepository.AddEntity(new RateCourse()
                {
                    CourseId = courseId,
                    Like = true,
                    UserId = userId,
                });
            }
            else
            {
                if (rate.Like==true)
                {
                    rate.Like = false;
                }
                else
                {
                    rate.Like = true;
                }
                _rateCourseRepository.UpdateEntity(rate);
            }

        }

        public void RateCourse(int courseId, int rate)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
            u.Type == ClaimTypes.NameIdentifier).Value);

            RateCourse rateCourse = _rateCourseRepository.Get(r => r.CourseId == courseId && r.UserId == userId).SingleOrDefault();
            if (rateCourse==null)
            {
                _rateCourseRepository.AddEntity(new Domain.Models.Users.RateCourse()
                {
                    CourseId = courseId,
                    Rate = rate,
                    UserId = userId
                });
            }
            else
            {
                rateCourse.Rate = rate;
                _rateCourseRepository.UpdateEntity(rateCourse);
            }
        }
    }
}
