using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.Models
{
    /// <summary>
    /// 分页数据结果集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedResultList<T> : List<T> where T : class
    {
        public int TotalItemsCount { get; set; }
        public PaginationBase Pagination { get; private set; }
        public int PageCount => TotalItemsCount / Pagination.PageSize + (TotalItemsCount % Pagination.PageSize > 0 ? 1 : 0);
        public bool HasPrevious => Pagination.PageIndex > 0;
        public bool HasNext => Pagination.PageIndex < PageCount - 1;

        public PaginatedResultList(PaginationBase pagination, IEnumerable<T> data, int totalItemsCount = 0)
        {
            Pagination = pagination;
            TotalItemsCount = totalItemsCount;
            AddRange(data);
        }
    }
}
