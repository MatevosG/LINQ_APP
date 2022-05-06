using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_APP
{
    public static class IEnumerableExtention
    {
        public static T _FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }
            return default(T);
        }

        public static IEnumerable<T> _Where<T>(this IEnumerable<T> source, Func<T, bool> Predicate)
        {
            foreach (var item in source)
                if (Predicate(item)) yield return item;
        }

        public static IEnumerable<TResult> _Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }

        public static IEnumerable<TResult> _SelectMany<T, TResult>(this IEnumerable<T> source, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in source)
            {
                foreach (var innerItem in selector(item))
                    yield return innerItem;
            }
        }

        public static IEnumerable<TResult> _Join<T, Th, TKey, TResult>(this IEnumerable<T> items,
            IEnumerable<Th> innerItems,
            Func<T, TKey> outerKeySelector,
            Func<Th, TKey> innerKeySelector,
            Func<T, Th, TResult> resultSelector)
        {
            foreach (var item in items)
            {
                foreach (var innerItem in innerItems)
                    if (outerKeySelector(item).Equals(innerKeySelector(innerItem)))
                        yield return resultSelector(item, innerItem);
            }
        }
    }
}
