using Jiavs.Domain.Core.Models;
using System;

namespace Jiavs.Domain.Models.ValueObjects
{
    /// <summary>
    /// 文章内容
    /// </summary>
    public class ArticleContent : ValueObject
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文章封面图片地址
        /// </summary>
        public string CoverUrl { get; set; }

        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 文章内容，html格式
        /// </summary>
        public string ContentHtml { get; set; }

        /// <summary>
        /// 文章内容，markdown格式
        /// </summary>
        public string ContentMarkdown { get; set; }

        private ArticleContent() { }

        public ArticleContent(string title,string coverUrl,string summary,string html,string markdown)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is empty", "Title");
            }


            Title = title;
            CoverUrl = coverUrl;
            this.Summary = summary;
            this.ContentHtml = html;
            this.ContentMarkdown = markdown;
            if (string.IsNullOrWhiteSpace(this.Summary))
            {
                //todo 生成summary
            }
        }
    }
}