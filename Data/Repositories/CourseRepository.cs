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
    public class CourseRepository:GenericRepository<Course> , ICourseRepository
    {
        private ZabanAmozContext db;
        public CourseRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
