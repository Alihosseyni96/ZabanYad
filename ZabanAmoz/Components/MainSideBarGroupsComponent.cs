using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZabanAmoz.Components
{
    public class MainSideBarGroupsComponent:ViewComponent
    {

        private ICourseGroupService _courseGroupService;
        public MainSideBarGroupsComponent(ICourseGroupService courseGroupService)
        {
            _courseGroupService = courseGroupService;
        }

        public   IViewComponentResult Invoke()
        {
             var groupList =   _courseGroupService.GetAllGroups();

            return  View("ShowGroupInMainSideBar", groupList);
        }

    }
}
