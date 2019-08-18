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
        /// <param name="array"></param>
        void Sort<T>(T[] array) where T : IComparable<T>;
    }
}
