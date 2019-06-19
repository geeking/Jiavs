using Jiavs.Domain.Core.Models;
using Jiavs.Domain.IRepositorys;
using Jiavs.Domain.Models;
using Jiavs.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jiavs.Infrastructure.Repository
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(JiavsContext jiavsContext) : base(jiavsContext)
        {

        }

        public PaginatedResultList<Article> GetArticlesSummary(ArticlePaginationParameter pagination)
        {
            var query = _jiavsContext.Articles.Where(x => x.Status.IsPublished && !x.Status.Deleted).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Title))
            {
                query = query.Where(x => x.Content.Title.Contains(pagination.Title.Trim().ToLowerInvariant()));
            }
            query = query.Skip(pagination.GetSkipCount()).Take(pagination.PageSize);
            var itemsCount = query.Count();
            var articles = query.Select(x => new Article(new Domain.Models.ValueObjects.ArticleContent(x.Content.Title, x.Content.CoverUrl, x.Content.Summary, null, null), x.Status, x.Settings, x.Author)
            ).AsNoTracking().ToList();
            return new PaginatedResultList<Article>(pagination, articles, itemsCount);
        }

        public async Task<PaginatedResultList<Article>> GetArticlesSummaryAsync(ArticlePaginationParameter pagination)
        {
            throw new NotImplementedException();
        }
    }
}
