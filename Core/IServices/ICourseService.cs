using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ICourseService
    {


        #region Admin Services
        List<TeacherViewModel> GetTeachersForShow();
        void AddCourse(CreateCourseViewModel createCourse);
        Tuple<List<ShowCourseForAdminViewModel>, int, int> GetCourseForShowAdmin(int pageId = 1, string searchBox = "");
        void DeleteCourse(int courseId);
        void ReturnCourse(int courseId);
        EditCourseViewModel GetCourseForEdit(int courseId);
        void EditCourse(EditCourseViewModel editCourse);
        #endregion

        #region View Services

        Tuple<List<ShowCourseViewModel>, int> GetCourseWithFilterToShow(string searchKey = null ,
            List<int> groupIds = null ,string orderBy = "all" , string price = null, int take = 2);

        ShowCourseDetialsViewModel GetCourseToShow(int courseId);
        List<ShowCourseViewModel> GetPopularCourses();
        #endregion
    }
}
