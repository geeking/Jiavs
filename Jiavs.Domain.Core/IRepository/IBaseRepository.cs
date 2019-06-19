using Jiavs.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jiavs.Domain.Core.IRepository
{
    public interface IBaseRepository<T> where T : AggregationRoot<T>
    {
        void Add(T entity);
        T GetById(uint id);
        Task<T> GetByIdAsync(uint id);

        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        void Update(T entity);

        void Delete(T entity);
        void DeleteById(uint id);
        void DeleteByIds(IEnumerable<uint> ids);
    }
}
