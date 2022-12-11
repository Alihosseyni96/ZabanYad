using Data.Context;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private ZabanAmozContext db;
        private DbSet<TEntity> dbset;
        public GenericRepository(ZabanAmozContext context)
        {
            db = context;
            dbset = context.Set<TEntity>();
        }


        public void AddEntity(TEntity entity)
        {
            dbset.Add(entity);
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbset.Remove(entity);
            db.SaveChanges();
        }



        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            if (where!=null)
            {
                return dbset.Where(where).AsQueryable();
            }
            return dbset.AsQueryable();
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> navigationProperty = null)
        {
            if (navigationProperty != null)
            {
                return dbset.Include(navigationProperty).SingleOrDefault(where);
            }
            return dbset.SingleOrDefault(where);

        }

        public bool IsExist(Expression<Func<TEntity, bool>> where = null)
        {
            return dbset.Any(where);
        }

        public void UpdateEntity(TEntity entity)
        {
            dbset.Update(entity);
            db.SaveChanges();
        }




    }
}
