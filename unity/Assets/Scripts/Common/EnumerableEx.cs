using System.Collections.Generic;

namespace System.Linq
{
    public static class EnumerableEx
    {
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (resultSelector == null) throw new ArgumentNullException("resultSelector");

            return ZipImpl(first, second, resultSelector);
        }

        private static IEnumerable<TResult> ZipImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return resultSelector(e1.Current, e2.Current);
                }
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, int, TResult> resultSelector)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (resultSelector == null) throw new ArgumentNullException("resultSelector");

            return ZipImpl(first, second, resultSelector);
        }

        private static IEnumerable<TResult> ZipImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, int, TResult> resultSelector)
        {
            int counter = 0;

            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return resultSelector(e1.Current, e2.Current, counter++);
                }
        }
    }
}