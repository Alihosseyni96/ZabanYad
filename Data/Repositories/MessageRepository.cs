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
    public class MessageRepository:GenericRepository<Message> , IMessageRepository
    {
        private ZabanAmozContext db;
        public MessageRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
