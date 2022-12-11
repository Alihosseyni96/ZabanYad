using Data.Context;
using Domain.IRepositories;
using Domain.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CourseToGroupRepository:GenericRepository<CourseToGroup> , ICourseToGroupRepository
    {
        private ZabanAmozContext db;
        public CourseToGroupRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }


    }
}
