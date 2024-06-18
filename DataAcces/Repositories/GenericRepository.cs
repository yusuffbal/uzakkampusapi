using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using DataAcces;

namespace DataAccess.Repositores
{
    public class GenericRepository<Tentity>(AppDbContext context) : IGenericRepository<Tentity>
    where Tentity : class
    {
        private readonly DbContext _context = context;
        private readonly DbSet<Tentity> _dbSet = context.Set<Tentity>();

        public async Task<Tentity> AddAsync(Tentity entity)
        {
            var added = await _dbSet.AddAsync(entity);
            return added.Entity;
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Tentity>> GetListByExpAsync(Expression<Func<Tentity, bool>> predicate,
         Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>> include = null,
         Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>> orderBy = null,
         int pageNumber = -1,
         int pageSize = -1)
        {

            IQueryable<Tentity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageNumber != -1) query = query.Skip((pageNumber - 1) * pageSize);

            if (pageSize != -1) query = query.Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<Tentity> SingleOrDefault(Expression<Func<Tentity, bool>> predicate,
            Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>> include = null)
        {

            IQueryable<Tentity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> IsExists(Expression<Func<Tentity, bool>> predicate)
        {

            IQueryable<Tentity> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.AnyAsync();
        }


        public async Task<Tentity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            // EntityState.Detached yapısını service class'sını anlatırken detaylandıracağım.
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public void Remove(Tentity entity)
        {
            _dbSet.Remove(entity);
        }

        public Tentity Update(Tentity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public IQueryable<Tentity> Where(Expression<Func<Tentity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<int> GetListCount(Expression<Func<Tentity, bool>> predicate, Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>> include = null)
        {
            IQueryable<Tentity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.CountAsync();
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Tentity>> GetListAsync(Expression<Func<Tentity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int AllCount(Expression<Func<Tentity, bool>> predicate = null, params Expression<Func<Tentity, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Tentity Add(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public Tentity GetFirstOrDefault(Expression<Func<Tentity, bool>> predicate = null, params Expression<Func<Tentity, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public List<Tentity> GetListByExp(Expression<Func<Tentity, bool>> predicate = null, Func<IQueryable<Tentity>, IOrderedQueryable<Tentity>> orderBy = null, Func<IQueryable<Tentity>, IIncludableQueryable<Tentity, object>> include = null, int pageNumber = -1, int pageSize = -1)
        {
            throw new NotImplementedException();
        }
    }
}
