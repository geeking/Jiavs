using Jiavs.Domain.Core.Models;
using Jiavs.Domain.Models.ValueObjects;
using System;

namespace Jiavs.Domain.Models
{
    public class Article : AggregationRoot<Article>
    {
        /// <summary>
        /// 文章作者
        /// </summary>
        public ArticleUser Author { get; set; }

        public ArticleStatus Status { get; set; }

        public ArticleSettings Settings { get; set; }
        public ArticleContent Content { get; set; }

        private Article()
        {
        }
        private Article(ArticleContent content, ArticleStatus status, ArticleSettings settings)
        {
            if (status.CreatedTime == null)
            {
                Status.CreatedTime = DateTime.UtcNow;
                Status.ModifyTime = DateTime.UtcNow;
            }
            this.Content = content;
            this.Status = status;
            this.Settings = settings;
        }
        public Article(ArticleContent content, ArticleStatus status, ArticleSettings settings, uint ownerId) : this(content, status, settings)
        {

            this.Author = new ArticleUser() { Id = ownerId };
        }
        public Article(ArticleContent content, ArticleStatus status, ArticleSettings settings, ArticleUser author) : this(content, status, settings)
        {

            this.Author = author;
        }
        public void Publish()
        {
            if (!Status.IsPublished)
            {
                Status.IsPublished = true;
                Status.PublishTime = DateTime.UtcNow;
            }
        }

        public void Delete()
        {
            if (!Status.Deleted)
            {
                Status.Deleted = true;
                Status.DeletedTime = DateTime.UtcNow;
            }
        }
    }
}