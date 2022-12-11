using Data.Context;
using Domain.IRepositories;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ZabanAmozContext db;
        public UserRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }


    }
}

