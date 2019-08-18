using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 排序接口
    /// </summary>
    interface ISort
    {
        /// <summary>
        /// 排序方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">待排序数组</param>
        /// <param name="sortAsc">true表示升序，false表示降序</param>
        void Sort<T>(T[] array, bool sortAsc) where T : IComparable<T>;
    }
}
