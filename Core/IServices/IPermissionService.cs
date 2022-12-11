using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IPermissionService
    {
        bool CheckRole(int roleId);
        List<int> ManegeAdminPanel();
        bool IsAdmin();
    }
}
