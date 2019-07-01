using Jiavs.Domain.Models;
using Jiavs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Infrastructure.DTO.SortMapping
{
    /// <summary>
    /// 配置文章DTO的可排序字段
    /// 如可按照访问量（VisitCount）排序，此处配置为由高到低的逆向排序（Revert=true）
    /// PropertyMapping基类默认会添加Id的逆向排序
    /// </summary>
    public class ArticlePropertyMapping : PropertyMapping<ArticleDto, Article>
    {
        public ArticlePropertyMapping() : base(new Dictionary<string, List<MappedProperty>>(StringComparer.OrdinalIgnoreCase)
        {
            [nameof(ArticleDto.Title)] = new List<MappedProperty> { new MappedProperty() { Name = nameof(Article.Content.Title), Revert = false } },
            [nameof(ArticleDto.VisitCount)] = new List<MappedProperty> { new MappedProperty() { Name = nameof(Article.Status.VisitCount), Revert = true } },
            [nameof(ArticleDto.PublishTime)] = new List<MappedProperty> { new MappedProperty() { Name = nameof(Article.Status.PublishTime), Revert = true } }
        })
        {
        }
    }
}
