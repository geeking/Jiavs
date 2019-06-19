using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jiavs.Domain.Core.IRepositorys
{
    public interface IUnitOfWork
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
