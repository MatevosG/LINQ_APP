using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_APP
{
    public static class IqueryableExtention
    {
        public static T _FirstOrDefault<T>(this IQueryable<T> source,Expression<Func<T,bool>> predicate)
        {
            foreach (var item in source)
                if(predicate.Compile().Invoke(item)) return item;
            return default(T);
        }
        public static IEnumerable<T> _Where<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
        {
            List<T> list = new List<T>();
            foreach (var item in source)
                if(predicate.Compile()(item))  list.Add(item);
            return list ;       
        }

        public static IEnumerable<K> _Select<T,K>(this IQueryable<T> source, Expression<Func<T, K>> selector)
        {
            List<K> list = new List<K>();
            foreach (var item in source)
                 list.Add(selector.Compile().Invoke(item));
            return list ; 
        }
        public static IQueryable<K> _SelectMany<T, K>(this IQueryable<T> source, Expression<Func<T,IQueryable< K>>> selector)
        {
            List<K> list = new List<K>();
            foreach (var item in source)
                foreach (var inneritem in selector.Compile().Invoke(item))
                    list.Add(inneritem);
            return list as IQueryable<K>;
        }
        public static T _LastOrDefault<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
        {
            var res = source.ToList();
            for (int i = res.Count()-1; i <= 0; i--)
            {
                  if(predicate.Compile().Invoke( res[i])) return res[i] ;
            }
            return default(T);
        }
    }
}
