using Jiavs.Domain.Core.Models;
using System;

namespace Jiavs.Domain.Models.ValueObjects
{
    /// <summary>
    /// 文章状态
    /// </summary>
    public class ArticleStatus : ValueObject
    {
        /// <summary>
        /// 文章浏览次数
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        /// 是否已发布
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 是否原创
        /// </summary>
        public bool IsOriginal { get; set; }

        /// <summary>
        /// 文章分类id
        /// </summary>
        public int ClassificationId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletedTime { get; set; }
    }
}