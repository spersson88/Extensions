static class Extensions
{
        /// <summary>
        /// Replace multiple characters with same value in string.
        /// </summary>
        /// <param name="str">Source string</param>
        /// <param name="newVal">Replace value</param>
        /// <param name="remove">Characters to replace</param>
        /// <returns>String with characters replaced by new value.</returns>
        public static string Replace(this string str, string newVal, params char[] remove)
        {
            var temp = str.Split(remove, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(newVal, temp);
        }

        /// <summary>
        /// Check if list contains source object.
        /// </summary>
        /// <param name="source">The object we are looking for.</param>
        /// <param name="list">A list of objects.</param>
        /// <returns>True if list contains source, otherwise false.</returns>
        public static bool IsIn<T>(this T source, params T[] list)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return list.Contains(source);
        }

        /// <summary>
        /// Remove last character in string.
        /// </summary>
        /// <returns>New string without last character.</returns>
        public static string RemoveLastCharacter(this string str)
        {
            return str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// Remove last X characters in string.
        /// </summary>
        /// <param name="length">Number of characters to remove.</param>
        /// <returns>New string without last X characters.</returns>
        public static string RemoveLast(this string str, int length)
        {
            return str.Substring(0, str.Length - length);
        }

        /// <summary>
        /// Remove first character in string.
        /// </summary>
        /// <returns>New string without first character.</returns>
        public static string RemoveFirstCharacter(this string str)
        {
            return str.Substring(1);
        }

        /// <summary>
        /// Remove first X characters in string.
        /// </summary>
        /// <param name="length">Number of characters to remove.</param>
        /// <returns>New string without first X characters.</returns>
        public static string RemoveFirst(this string str, int length)
        {
            return str.Substring(length);
        }

        /// <summary>
        /// Check if date is between start and end date.
        /// </summary>
        /// <param name="dt">Date to check.</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <returns>True if date is between start and end dates.</returns>
        public static bool Between(this DateTime dt, DateTime start, DateTime end)
        {
            return dt >= start && dt <= end;
        }

        /// <summary>
        /// Check if value is between start and end, exclusive.
        /// </summary>
        /// <param name="val">Actual value</param>
        /// <param name="start">Start value</param>
        /// <param name="end">End value</param>
        /// <returns>True if val is larger than start and smaller than end. Otherwise false.</returns>
        public static bool IsBetween<T>(this T val, T start, T end) where T : IComparable<T>
        {
            return val.CompareTo(start) > 0 && val.CompareTo(end) < 0;
        }

        /// <summary>
        /// Check if value is between start and end, inclusive.
        /// </summary>
        /// <param name="val">Actual value</param>
        /// <param name="start">Start value</param>
        /// <param name="end">End value</param>
        /// <returns>True if val is larger than or equal to start and smaller than or equal to end. Otherwise false.</returns>
        public static bool IsWithin<T>(this T val, T start, T end) where T : IComparable<T>
        {
            return val.CompareTo(start) >= 0 && val.CompareTo(end) <= 0;
        }

        /// <summary>
        /// Reverse an array
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="a">Array to reverse</param>
        public static void Reverse<T>(this T[] a)
        {
            for (int i = 0; i < a.Length / 2; i++)
            {
                var temp = a[i];
                a[i] = a[a.Length - 1 - i];
                a[a.Length - 1 - i] = temp;
            }
        }

        /// <summary>
        /// Shuffle an IList
        /// </summary>
        /// <typeparam name="T">Type of IList</typeparam>
        /// <param name="a">IList to shuffle.</param>
        /// <param name="r">Random used to randomize new position.</param>
        public static void Shuffle<T>(this IList<T> a, Random r)
        {
            for (var i = 0; i < a.Count - 1; i++)
                a.Swap(i, r.Next(i, a.Count));
        }

        /// <summary>
        /// Swap two places in IList.
        /// </summary>
        /// <typeparam name="T">Type of IList</typeparam>
        /// <param name="a">IList to perform swap on.</param>
        /// <param name="i">First index to swap.</param>
        /// <param name="j">Second index to swap.</param>
        public static void Swap<T>(this IList<T> a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        /// <summary>
        /// Batch an IEnumerable
        /// </summary>
        /// <typeparam name="T">Type of IEnumerable.</typeparam>
        /// <param name="items">Items to batch.</param>
        /// <param name="maxItems">Max items in batch.</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                .GroupBy(x => x.inx / maxItems)
                .Select(g => g.Select(x => x.item));
        }
}
