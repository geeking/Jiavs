using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Infrastructure
{
    public interface IPropertyMapping
    {
        Dictionary<string, List<MappedProperty>> MappingDictionary { get; }
    }
}
