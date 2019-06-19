using Jiavs.Domain.Core.Models;

namespace Jiavs.Domain.Models.ValueObjects
{
    /// <summary>
    /// 关于每个文章的设置项
    /// </summary>
    public class ArticleSettings : ValueObject
    {
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