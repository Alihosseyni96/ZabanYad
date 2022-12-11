using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IUserAdminService
    {
        Tuple<List<ShowUsersForAdminPanelViewModel>,int, int> GetUsersForAdminPanel(int pageId = 1 , string searchBox="");
        void DeleteUser(int userId);
        void ReturnUser(int userId);
        List<ShowRolesForAdminPanelViewMode> GetRolesForShow();
        void CreateUser(CreateUserViewModel createUser);
        UserForEditAdminViewModel GetUserForEdit(int userId);
        void EditUser(UserForEditAdminViewModel userForEdit);



    }
}
