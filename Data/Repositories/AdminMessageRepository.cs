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
    public class AdminMessageRepository : GenericRepository<AdminMessage> , IAdminMessageRepository
    {
        private ZabanAmozContext db;
        public AdminMessageRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
