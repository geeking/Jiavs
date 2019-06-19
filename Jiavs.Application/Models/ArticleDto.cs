using System;

namespace Jiavs.Application.Models
{
    public class ArticleDto
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
        /// 文章作者
        /// </summary>
        public ArticleUserDto Author { get; set; }

        /// <summary>
        /// 文章浏览次数
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        /// 是否原创
        /// </summary>
        public bool IsOriginal { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishTime { get; set; }

        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 是否开放评论
        /// </summary>
        public bool CanComment { get; set; }

        /// <summary>
        /// 是否可以打分
        /// </summary>
        public bool CanGrade { get; set; }
    }
}