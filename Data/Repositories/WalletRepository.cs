using Data.Context;
using Domain.IRepositories;
using Domain.Models.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class WalletRepository :GenericRepository<Wallet> , IWalletRepository
    {
        private ZabanAmozContext db;
        public WalletRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }


    }
}
