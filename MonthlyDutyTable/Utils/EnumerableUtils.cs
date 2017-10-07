using System;
using System.Collections.Generic;

namespace MonthlyDutyTable.Utils
{
    public static class EnumerableUtils
    {
        public static IEnumerable<S> Pairwise<T, S>(this IEnumerable<T> @this, Func<T,T,S> mapper)
        {
            T previous = default(T);

            using (var it = @this.GetEnumerator())
            {
                if (it.MoveNext())
                    previous = it.Current;

                while (it.MoveNext())
                {
                    yield return mapper(previous, it.Current);
                    previous = it.Current;
                }
            }
        }

        public static List<T> AllWithMax<T, M>(this IEnumerable<T> @this, Func<T, M> selector)
            where M : IComparable
        {
            var allWithMax = new List<T>();

            using (var item = @this.GetEnumerator())
            {
                if (!item.MoveNext())
                    throw new ArgumentException("sequence is empty");

                M max = selector(item.Current);
                allWithMax.Add(item.Current);

                while (item.MoveNext())
                {
                    var otherValue = selector(item.Current);
                    var comparingResult = otherValue.CompareTo(max);
                    if (comparingResult == 0)
                        allWithMax.Add(item.Current);
                    else if (comparingResult > 0)
                    {
                        allWithMax.Clear();
                        allWithMax.Add(item.Current);
                        max = otherValue;
                    }
                }
            }
            return allWithMax;
        }
    }
}
