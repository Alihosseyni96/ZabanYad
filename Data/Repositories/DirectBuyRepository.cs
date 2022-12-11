using Data.Context;
using Domain.IRepositories;
using Domain.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DirectBuyRepository:GenericRepository<DirectBuy> , IDirectBuyRepository
    {
        private ZabanAmozContext db;
        public DirectBuyRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }


    }
}
