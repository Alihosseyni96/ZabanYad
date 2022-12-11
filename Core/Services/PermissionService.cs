using Core.IServices;
using Domain.IRepositories;
using ImageProcessor.Imaging.Colors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PermissionService : IPermissionService
    {
        private IUserRoleRepository _userRoleRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public PermissionService(IUserRoleRepository userRoleRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRoleRepository = userRoleRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool CheckRole(int roleId)
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                       u.Type == ClaimTypes.NameIdentifier).Value);
           return _userRoleRepository.Get(ur => ur.UserId == userId).Select(ur => ur.RoleId).
                Any(ur => ur == roleId);

        }

        public bool IsAdmin()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                       u.Type == ClaimTypes.NameIdentifier).Value);

            return _userRoleRepository.Get(ur => ur.UserId == userId).Select(ur => ur.RoleId)
                .Any(ur => ur == 1);
        }

        public List<int> ManegeAdminPanel()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u =>
                       u.Type == ClaimTypes.NameIdentifier).Value);

            return _userRoleRepository.Get(ur => ur.UserId == userId).Select(ur => ur.RoleId).ToList();
        }
    }
}
