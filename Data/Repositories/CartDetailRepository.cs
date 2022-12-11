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
    public class CartDetailRepository:GenericRepository<CartDetail> , ICartDetailRepository
    {
        private ZabanAmozContext db;
        public CartDetailRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
