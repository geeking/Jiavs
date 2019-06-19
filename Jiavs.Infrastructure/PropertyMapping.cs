using Jiavs.Domain.Core.Models;
using System.Collections.Generic;

namespace Jiavs.Infrastructure
{
    public abstract class PropertyMapping<TSource, TDestination> : IPropertyMapping where TDestination : IEntity
    {
        public Dictionary<string, List<MappedProperty>> MappingDictionary { get; }

        protected PropertyMapping(Dictionary<string, List<MappedProperty>> mapping)
        {
            MappingDictionary = mapping;
            if (!MappingDictionary.ContainsKey(nameof(IEntity.Id)))
            {
                MappingDictionary[nameof(IEntity.Id)] = new List<MappedProperty>
                {
                    new MappedProperty{Name=nameof(IEntity.Id),Revert=true}
                };
            }
        }
    }
}