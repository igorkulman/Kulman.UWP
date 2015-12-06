using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using JetBrains.Annotations;

namespace Kulman.UWP.Code
{
    /// <summary>
    /// Useful extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Add a range of items to a hash set
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="set">Hash set to add to</param>
        /// <param name="items">Collection of items</param>
        public static void AddRange<T>([NotNull] this HashSet<T> set, [NotNull] IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                set.Add(item);
            }
        }

        /// <summary>
        /// Adds a range of items to an observable collection
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="collection">Collection to add to</param>
        /// <param name="items">Collection of items</param>
        public static void AddRange<T>([NotNull] this ObservableCollection<T> collection, [NotNull] IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Toggles visibility of a framework element
        /// </summary>
        /// <param name="elem">Framewotk element</param>
        public static void ToggleVisibility([NotNull] this FrameworkElement elem)
        {
            elem.Visibility = elem.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Executes given action on each item in the collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="enumeration">Collection of items</param>
        /// <param name="action">Action to execute</param>
        public static void ForEach<T>([NotNull] this IEnumerable<T> enumeration, [NotNull] Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
