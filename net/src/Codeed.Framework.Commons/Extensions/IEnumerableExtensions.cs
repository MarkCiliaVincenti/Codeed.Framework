﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                return;
            }

            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static string ToCommaString(this IEnumerable<string> enumerable)
        {
            return enumerable == null || !enumerable.Any() ?
                    string.Empty :
                    string.Join(",", enumerable);
        }

        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.RandomElementUsing(new Random(DateTimeOffset.UtcNow.Millisecond));
        }

        public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
        {
            int index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }
        public static void CompareList<TSource, TDest>(this IEnumerable<TSource> source,
            IEnumerable<TDest> dest,
            Func<TSource, TDest, bool> compareLists,
            Action<TDest> existsOnlyInDestination)
        {
            source.CompareList(dest, compareLists, existsOnlyInDestination, null, null);
        }

        public static void CompareList<TSource, TDest>(this IEnumerable<TSource> source,
            IEnumerable<TDest> dest,
            Func<TSource, TDest, bool> compareLists,
            Action<TDest> existsOnlyInDestination,
            Action<TSource> existsOnlyInSource)
        {
            source.CompareList(dest, compareLists, existsOnlyInDestination, existsOnlyInSource, null);
        }

        public static void CompareList<TSource, TDest>(
            this IEnumerable<TSource> source,
            IEnumerable<TDest> dest,
            Func<TSource, TDest, bool> compareLists,
            Action<TDest> existsOnlyInDestination,
            Action<TSource> existsOnlyInSource,
            Action<TSource, TDest> existsOnBoth)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (dest is null)
            {
                throw new ArgumentNullException(nameof(dest));
            }

            if (compareLists is null)
            {
                throw new ArgumentNullException(nameof(compareLists));
            }

            if (!(existsOnlyInDestination is null))
            {
                var newOnDestItems = dest.Where(d => !source.Any(s => compareLists(s, d)));
                foreach (var newOnDest in newOnDestItems)
                {
                    existsOnlyInDestination(newOnDest);
                }
            }

            if (!(existsOnlyInSource is null))
            {
                var newOnSourceList = source.Where(s => !dest.Any(d => compareLists(s, d)));
                foreach (var newOnSource in newOnSourceList)
                {
                    existsOnlyInSource(newOnSource);
                }
            }

            if (!(existsOnBoth is null))
            {
                foreach (var sourceItem in source)
                {
                    var destItem = dest.FirstOrDefault(d => compareLists(sourceItem, d));
                    if (destItem != null)
                    {
                        existsOnBoth(sourceItem, destItem);
                    }
                }
            }
        }
    }
}
