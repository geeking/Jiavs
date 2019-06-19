using Jiavs.Domain.Core.IRepositorys;
using Jiavs.Infrastructure.Repository.Context;
using System.Threading.Tasks;

namespace Jiavs.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JiavsContext _jiavsContext;

        public UnitOfWork(JiavsContext jiavsContext)
        {
            this._jiavsContext = jiavsContext;
        }

        public bool Commit()
        {
            return _jiavsContext.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _jiavsContext.SaveChangesAsync() > 0;
        }
    }
}