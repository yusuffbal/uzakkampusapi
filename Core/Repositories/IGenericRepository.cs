using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetListByExpAsync(
         Expression<Func<TEntity, bool>> predicate,
         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         int pageNumber = -1,
         int pageSize = -1);


        Task<int> GetListCount(
         Expression<Func<TEntity, bool>> predicate,
         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> SingleOrDefault(
         Expression<Func<TEntity, bool>> predicate,
         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<bool> IsExists(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        void Remove(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
