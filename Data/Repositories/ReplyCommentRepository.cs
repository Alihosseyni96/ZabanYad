using Data.Context;
using Domain.IRepositories;
using Domain.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReplyCommentRepository: GenericRepository<ReplyComment> , IReplyCommentRepository
    {
        private ZabanAmozContext db;
        public ReplyCommentRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
