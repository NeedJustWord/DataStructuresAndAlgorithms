using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 排序接口
    /// </summary>
    public interface ISort
    {
        /// <summary>
        /// 将<paramref name="array"/>按指定要求排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">待排序数组</param>
        /// <param name="sortAsc">true表示升序，false表示降序</param>
        /// <exception cref="ArgumentNullException"></exception>
        void Sort<T>(T[] array, bool sortAsc) where T : IComparable<T>;

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
        void Sort<T>(T[] array, int left, int right, bool sortAsc) where T : IComparable<T>;
    }
}
