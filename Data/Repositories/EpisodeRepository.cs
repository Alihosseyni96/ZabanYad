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
    public class EpisodeRepository:GenericRepository<Episode> , IEpisodeRepository
    {
        private ZabanAmozContext db;
        public EpisodeRepository(ZabanAmozContext context) : base(context)
        {
            db = context;
        }

    }
}
