using Jiavs.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Models
{
    /// <summary>
    /// 文章分页查询参数
    /// </summary>
    public class ArticlePaginationParameter : PaginationBase
    {
        /// <summary>
        /// 用于搜索的标题
        /// </summary>
        public string Title { get; set; }
    }
}
