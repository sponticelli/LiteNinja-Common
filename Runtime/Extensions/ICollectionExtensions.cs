using System.Collections.Generic;

namespace LiteNinja.Common.Extensions
{
    public static class ICollectionExtensions
    {
        public static bool AddIfNotContains<T>(this ICollection<T> collection, T item)
        {
            if (collection.Contains(item))
            {
                return false;
            }

            collection.Add(item);
            return true;
        }
        
        /// <summary>
        /// Returns whether this source is empty.
        /// </summary>
        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            return collection.Count == 0;
        }
        
        /// <summary>
        /// Add all elements of other to the given source.
        /// </summary>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> other)
        {
            if (other == null)//nothing to add
            {
                return;
            }

            foreach (var obj in other)
            {
                collection.Add(obj);
            }
        }
    }
}