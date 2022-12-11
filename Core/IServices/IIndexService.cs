using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IIndexService
    {
        List<ShowCourseViewModel> GetPopularCourses();
        List<ShowMainGroupsForIndex> GetMainGroups();
        List<TeachersViewMode> GetTeachers();
        ShowItemsForIndexPage GetItemsForIndex();

        bool ShowAdminButton();
    }
}
