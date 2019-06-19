using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.Models
{
    /// <summary>
    /// 聚合根
    /// </summary>
    public abstract class AggregationRoot<T> : IEntity where T :AggregationRoot<T>
    {
        public uint Id { get; set; }


        public override bool Equals(object obj)
        {
            var other = obj as T;
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (other == null)
            {
                return false;
            }
            return Id == other.Id;
        }

        public static bool operator ==(AggregationRoot<T> a, AggregationRoot<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(AggregationRoot<T> a, AggregationRoot<T> b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{typeof(T).Name} [Id={Id}]";
        }
    }
}
