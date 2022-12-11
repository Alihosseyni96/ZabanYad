using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface ICourseGroupService
    {
        #region Admin Services
        void AddCourseGroup(CreateCourseGroupViewModel createCourseGroup);
        List<ShowCourseGroupsViewModel> GetAllCourseGroups();

        EditCourseGroupViewModel GetGroupForEdit(int mainGroupId);
        void EditCourseGroup(EditCourseGroupViewModel editCourseGroup);

        #endregion


        #region View Services

          List<ShowGroupsViewModel> GetAllGroups();

         List<ShowMainGroupsForIndex> GetMainGroups();

        #endregion

    }
}
