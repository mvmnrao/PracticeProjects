using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndDataStructures
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Apply<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }

            return items;
        }
    }
}
