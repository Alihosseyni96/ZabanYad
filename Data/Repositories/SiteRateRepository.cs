using Data.Context;
using Domain.IRepositories;
using Domain.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SiteRateRepository:GenericRepository<SiteRate> , ISiteRateRepository
    {
        private ZabanAmozContext db;
        public SiteRateRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
