using Jiavs.Domain.Core.Models;
using Jiavs.Domain.Models;
using Jiavs.Infrastructure.DTO;
using System.Threading.Tasks;

namespace Jiavs.Application.IServices
{
    public interface IArticleService
    {
        /// <summary>
        /// 获取指定文章的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ArticleDto GetArticle(uint id);

        /// <summary>
        /// 获取指定文章的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArticleDto> GetArticleAsync(uint id);

        /// <summary>
        /// 获取每个文章的摘要和其他信息，但不包含全文内容
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        PaginatedResultList<ArticleDto> GetArticlesSummary(ArticlePaginationParameter pagination);

        /// <summary>
        /// 获取每个文章的摘要和其他信息，但不包含全文内容
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Task<PaginatedResultList<ArticleDto>> GetArticlesSummaryAsync(ArticlePaginationParameter pagination);

        /// <summary>
        /// 创建文章
        /// </summary>
        /// <param name="articleDto"></param>
        bool Create(ArticleDto articleDto);

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        bool Delete(uint id);

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="articleDto"></param>
        bool Update(ArticleDto articleDto);
    }
}