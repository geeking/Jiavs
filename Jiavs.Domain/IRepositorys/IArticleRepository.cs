using Jiavs.Domain.Core.IRepository;
using Jiavs.Domain.Core.Models;
using Jiavs.Domain.Models;
using System.Threading.Tasks;

namespace Jiavs.Domain.IRepositorys
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        PaginatedResultList<Article> GetArticlesSummary(ArticlePaginationParameter pagination);

        Task<PaginatedResultList<Article>> GetArticlesSummaryAsync(ArticlePaginationParameter pagination);
    }
}