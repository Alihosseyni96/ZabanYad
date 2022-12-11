using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        void AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        TEntity GetEntity(Expression<Func<TEntity,bool>> where = null, Expression<Func<TEntity, object>> navigationProperty = null);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where = null);
        bool IsExist(Expression<Func<TEntity, bool>> where = null);
        void Delete(TEntity entity);
    }
}
