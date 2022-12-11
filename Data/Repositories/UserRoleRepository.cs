using Data.Context;
using Domain.IRepositories;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole> , IUserRoleRepository
    {
        private ZabanAmozContext db;
        public UserRoleRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
