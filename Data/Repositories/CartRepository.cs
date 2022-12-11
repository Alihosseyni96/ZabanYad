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
    public class CartRepository:GenericRepository<Cart> , ICartRepository
    {
        private ZabanAmozContext db;
        public CartRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
