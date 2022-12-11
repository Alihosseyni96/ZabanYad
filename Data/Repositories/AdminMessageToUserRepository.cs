using Data.Context;
using Domain.IRepositories;
using Domain.Models.AdminMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AdminMessageToUserRepository : GenericRepository<AdminMessageToUser> ,IAdminMessageToUserRepository
    {
        private ZabanAmozContext db;
        public AdminMessageToUserRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
