using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Jiavs.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 向IQueryable应用排序规则
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="orderBy">排序字段，多个用","分隔，如:id desc,title</param>
        /// <param name="propertyMapping">字段的映射规则</param>
        /// <returns></returns>
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source,string orderBy,IPropertyMapping propertyMapping)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var mappingDictionary = propertyMapping.MappingDictionary;
            if (mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            var orderByAfterSplit = orderBy.Split(',');
            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimmedOrderByClause = orderByClause.Trim();
                var orderDescending = trimmedOrderByClause.EndsWith(" desc");
                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ", StringComparison.Ordinal);
                var propertyName = indexOfFirstSpace == -1 ?
                    trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);
                if (!mappingDictionary.ContainsKey(propertyName))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }
                var mappedProperties = mappingDictionary[propertyName];
                if (mappedProperties == null)
                {
                    throw new ArgumentNullException(propertyName);
                }
                mappedProperties.Reverse();
                foreach (var destinationProperty in mappedProperties)
                {
                    if (destinationProperty.Revert)
                    {
                        orderDescending = !orderDescending;
                    }
                    source = source.OrderBy(destinationProperty.Name + (orderDescending ? " descending" : " ascending"));
                }
            }

            return source;
        }
    }
}
