using Core.IServices;
using Core.ViewModels;
using Data.Context;
using Domain.IRepositories;
using Domain.Models.Admin;
using Domain.Models.Cart;
using Domain.Models.Comment;
using Domain.Models.Course;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private ICourseRepository _courseRepository;
        private IUserRepository _userRepository;
        private ICommentRepository _commentRepository;
        private IRateCourseRepository _rateCourseRepository;
        private IUserToCourseRepository _userToCourseRepository;
        private IReplyCommentRepository _replyCommentRepository;
        private ISiteRateRepository _siteRateRepository;
        public AdminDashboardService(ICourseRepository courseRepository, IUserRepository userRepository,
            ICommentRepository commentRepository, IRateCourseRepository rateCourseRepository,
            IUserToCourseRepository userToCourseRepository, IReplyCommentRepository replyCommentRepository,
            ISiteRateRepository siteRateRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _rateCourseRepository = rateCourseRepository;
            _userToCourseRepository = userToCourseRepository;
            _replyCommentRepository = replyCommentRepository;
            _siteRateRepository = siteRateRepository;
        }



        public AdminDashboardViewModel GetDashboardInfo()
        {
            return new AdminDashboardViewModel()
            {
                CourseCount = _courseRepository.Get().Count(),
                CoursesVisit = _courseRepository.Get().Sum(c => c.Visit),
                UserCount = _userRepository.Get().Count(),
                Comments = _commentRepository.Get().Count(),
                NotShownComment = _commentRepository.Get(c => !c.Show).Count(),

            };
        }



        public List<SiteRateViewModel> GetSiteRateForDashboard(int maxValue = 20)
        {


            return _siteRateRepository.Get().OrderByDescending(r => r.CreateDate).Take(7).Select(r => new SiteRateViewModel()
            {
                CreateDate = r.CreateDate,
                Rate = (r.TotalDayRate / double.Parse(maxValue.ToString())) * 100,
            }).ToList();
        }

    }

}
