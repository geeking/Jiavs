using Jiavs.Domain.Core.IRepository;
using Jiavs.Domain.Core.Models;
using Jiavs.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiavs.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : AggregationRoot<T>
    {
        protected readonly JiavsContext _jiavsContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(JiavsContext jiavsContext)
        {
            _dbSet = jiavsContext.Set<T>();
        }

        public void Add(T entity)
        {
            //_jiavsContext.Add<T>(entity);
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            //_jiavsContext.Remove<T>(entity);
            _dbSet.Remove(entity);
        }

        public void DeleteById(uint id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void DeleteByIds(IEnumerable<uint> ids)
        {
            if (ids == null)
            {
                return;
            }
            var items = _dbSet.Find(ids);
            _dbSet.RemoveRange(items);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public T GetById(uint id)
        {
            return _dbSet.Find(id);
        }

        public Task<T> GetByIdAsync(uint id)
        {
            return _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}