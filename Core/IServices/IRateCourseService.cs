using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IRateCourseService
    {
        void LikeCourse(int courseId);
        void RateCourse(int courseId, int rate);
        CourseRateViewModel GetCourseRate(int courseId);
    }
}
