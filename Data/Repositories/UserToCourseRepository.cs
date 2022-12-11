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
    public class UserToCourseRepository: GenericRepository<UserToCourse> , IUserToCourseRepository
    {
        private ZabanAmozContext db;
        public UserToCourseRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
