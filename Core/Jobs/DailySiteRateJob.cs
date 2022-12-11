using Core.IServices;
using Data.Context;
using Domain.Models.Admin;
using Domain.Models.Cart;
using Domain.Models.Comment;
using Domain.Models.Course;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Jobs
{
    [DisallowConcurrentExecution]
    public class DailySiteRateJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            var option = new DbContextOptionsBuilder<ZabanAmozContext>();
            option.UseSqlServer("Data source=.; Initial Catalog= ZabanAmozDb; Integrated Security= True; MultipleActiveResultSets=True");
            using (ZabanAmozContext _db = new ZabanAmozContext(option.Options))
            {
                #region Calculations
                int userCount = 0;
                IQueryable<User> users = _db.Users;
                if (users != null)
                {
                    userCount = users.Count();
                }

                int courseViews = 0;

                IQueryable<Course> courses = _db.Courses;
                if (courses != null)
                {
                    courseViews = courses.Sum(c => c.Visit);
                }

                int courseLike = 0;
                IQueryable<RateCourse> rateCourse = _db.RateCourses;
                if (rateCourse != null)
                {
                    courseLike = rateCourse.Where(r => r.Like == true).Count();
                }
                int commentCount = 0;
                IQueryable<Comment> comments = _db.Comments;
                if (comments != null)
                {
                    commentCount = comments.Count();
                }
                int replyCount = 0;
                IQueryable<ReplyComment> replyComments = _db.ReplyComments;
                if (replyComments != null)
                {
                    replyCount = replyComments.Count();
                }
                int saleCourse = 0;
                IQueryable<UserToCourse> userToCourses = _db.Set<UserToCourse>();
                if (userToCourses!=null)
                {
                    saleCourse = userToCourses.Count();
                }

                int previousRate = 0;
                List<SiteRate> PreviousSiteRate = _db.SiteRates.OrderByDescending(r =>
                r.CreateDate).ToList();

                if (PreviousSiteRate != null)
                {
                    previousRate = PreviousSiteRate.Sum(r => r.TotalDayRate);
                }

                #endregion

                _db.SiteRates.Add(new Domain.Models.Admin.SiteRate()
                {
                    TotalDayRate = ((courseViews + courseLike + saleCourse + commentCount + replyCount) - previousRate),
                    UserCount = userCount,
                    CreateDate = DateTime.Now
                });
                _db.SaveChanges();


            }
            return Task.CompletedTask;

        }
    }
}
