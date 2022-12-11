using Domain.Models.AdminMessage;
using Domain.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
    }
}
