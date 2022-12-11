using Core.IServices;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ZabanAmoz.Pages.Admin.Dashboard
{
    public class IndexModel : PageModel
    {
        private IAdminDashboardService _adminDashboardService;
        public IndexModel(IAdminDashboardService adminDashboardService)
        {
            _adminDashboardService = adminDashboardService;
        }


        public AdminDashboardViewModel DashboardInfo { get; set; }
        public List<SiteRateViewModel> SiteRate { get; set; }
        public void OnGet(int limitRate =20)
        {

            DashboardInfo = _adminDashboardService.GetDashboardInfo();
            SiteRate = _adminDashboardService.GetSiteRateForDashboard(limitRate);
        }
    }
}
