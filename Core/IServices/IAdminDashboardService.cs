using Core.ViewModels;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IAdminDashboardService
    {
        AdminDashboardViewModel GetDashboardInfo();
        List<SiteRateViewModel> GetSiteRateForDashboard(int maxValue = 20);
    }
}
