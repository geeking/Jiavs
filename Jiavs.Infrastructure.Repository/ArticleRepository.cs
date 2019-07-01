using Jiavs.Domain.Core.Models;
using Jiavs.Domain.IRepositorys;
using Jiavs.Domain.Models;
using Jiavs.Infrastructure.DTO;
using Jiavs.Infrastructure.Extensions;
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
        private readonly IPropertyMappingContainer _mappingContainer;

        public ArticleRepository(JiavsContext jiavsContext, IPropertyMappingContainer mappingContainer) : base(jiavsContext)
        {
            this._mappingContainer = mappingContainer;
        }

        public PaginatedResultList<Article> GetArticlesSummary(ArticlePaginationParameter pagination)
        {
            var query = _dbSet.Where(x => x.Status.IsPublished && !x.Status.Deleted).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Title))
            {
                query = query.Where(x => x.Content.Title.Contains(pagination.Title.Trim().ToLowerInvariant()));
            }
            //数据库中已发表文章总数
            var itemsCount = query.Select(x => x.Id).Count();

            query = query.Skip(pagination.GetSkipCount()).Take(pagination.PageSize);
            query = query.ApplySort(pagination.OrderBy, _mappingContainer.Resolve<ArticleDto, Article>());
            var articles = query.Select(
                x => new Article(
                    new Domain.Models.ValueObjects.ArticleContent(x.Content.Title, x.Content.CoverUrl, x.Content.Summary, null, null),
                    x.Status,
                    x.Settings,
                    x.Author)
            ).AsNoTracking().ToList();
            return new PaginatedResultList<Article>(pagination, articles, itemsCount);
        }

        public async Task<PaginatedResultList<Article>> GetArticlesSummaryAsync(ArticlePaginationParameter pagination)
        {
            var query = _dbSet.Where(x => x.Status.IsPublished && !x.Status.Deleted).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Title))
            {
                query = query.Where(x => x.Content.Title.Contains(pagination.Title.Trim().ToLowerInvariant()));
            }
            //数据库中已发表文章总数
            var itemsCount = await query.Select(x => x.Id).CountAsync();

            query = query.Skip(pagination.GetSkipCount()).Take(pagination.PageSize);
            query = query.ApplySort(pagination.OrderBy, _mappingContainer.Resolve<ArticleDto, Article>());
            var articles = await query.Select(
                x => new Article(
                    new Domain.Models.ValueObjects.ArticleContent(x.Content.Title, x.Content.CoverUrl, x.Content.Summary, null, null),
                    x.Status,
                    x.Settings,
                    x.Author)
            ).AsNoTracking().ToListAsync();
            return new PaginatedResultList<Article>(pagination, articles, itemsCount);
        }
    }
}
