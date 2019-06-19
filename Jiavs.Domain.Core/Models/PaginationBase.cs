using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.Models
{
    /// <summary>
    /// 分页请求基类
    /// </summary>
    public class PaginationBase
    {
        private const int DefaultPageSize = 10;
        private int _pageSize = DefaultPageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value <= 0)
                {
                    _pageSize = DefaultPageSize;
                }
                else if (value > MaxPageSize)
                {
                    _pageSize = MaxPageSize;
                }
                else
                {
                    _pageSize = value;
                }
            }
        }
        private int _pageIndex;
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (value <= 0)
                {
                    _pageIndex = 0;
                }
                else
                {
                    _pageIndex = value;
                }
            }
        }
        public string OrderBy { get; set; } = $"{nameof(IEntity.Id)} desc";
        private int _maxPageSize;

        public int MaxPageSize
        {
            get { return _maxPageSize; }
            set { _maxPageSize = value <= 0 ? DefaultPageSize : value; }
        }

        public int GetSkipCount()
        {
            if (PageIndex == 0)
            {
                return 0;
            }
            else
            {
                return PageIndex * PageSize;
            }
        }
    }
}
