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
    public class CommentRepository:GenericRepository<Comment> , ICommentRepository
    {
        private ZabanAmozContext db;
        public CommentRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
