using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 抽象排序类
    /// </summary>
    public abstract class BaseSort : ISort
    {
        /// <summary>
        /// 将<paramref name="array"/>按指定要求排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">待排序数组</param>
        /// <param name="sortAsc">true表示升序，false表示降序</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Sort<T>(T[] array, bool sortAsc) where T : IComparable<T>
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length < 2) return;

            Sort(array, 0, array.Length - 1, sortAsc);
        }

        /// <summary>
        /// 将<paramref name="array"/>的子数组按指定要求排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">数据</param>
        /// <param name="left">子数组的左边界</param>
        /// <param name="right">子数组的右边界</param>
        /// <param name="sortAsc">true表示升序，false表示降序</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Sort<T>(T[] array, int left, int right, bool sortAsc) where T : IComparable<T>
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (left < 0 || left >= array.Length) throw new ArgumentOutOfRangeException(nameof(left));
            if (right < left || right >= array.Length) throw new ArgumentOutOfRangeException(nameof(right));

            if (sortAsc) Sort(array, left, right, Asc);
            else Sort(array, left, right, Desc);
        }

        protected abstract void Sort<T>(T[] array, int left, int right, Func<T, T, bool> func) where T : IComparable<T>;

        /// <summary>
        /// 判断<paramref name="t1"/>是否比<paramref name="t2"/>大
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        private bool Asc<T>(T t1, T t2) where T : IComparable<T>
        {
            return t1.CompareTo(t2) > 0;
        }

        /// <summary>
        /// 判断<paramref name="t1"/>是否比<paramref name="t2"/>小
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        private bool Desc<T>(T t1, T t2) where T : IComparable<T>
        {
            return t1.CompareTo(t2) < 0;
        }
    }
}
