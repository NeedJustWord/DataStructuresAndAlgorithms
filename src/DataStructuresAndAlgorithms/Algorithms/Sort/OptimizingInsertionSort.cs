using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 优化版插入排序
    /// <para>用二分法查找插入位置</para>
    /// </summary>
    public class OptimizingInsertionSort : BaseSort
    {
        protected override void SortInternal<T>(T[] array, int left, int right, bool sortAsc)
        {
            var func = GetFunc<T>(sortAsc);
            T key;
            int i;
            int insertIndex;

            for (int j = left + 1; j <= right; j++)
            {
                key = array[j];
                insertIndex = GetInsertIndex(array, left, j - 1, key, func);
                //将array[j]插入到已排好序的序列array[left...j-1]
                for (i = j - 1; i >= insertIndex; i--)
                {
                    array[i + 1] = array[i];
                }
                array[insertIndex] = key;
            }
        }

        /// <summary>
        /// <para>升序的时候，找到不小于<paramref name="key"/>的最大下标</para>
        /// <para>降序的时候，找到不大于<paramref name="key"/>的最大下标</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        private int GetInsertIndex<T>(T[] array, int left, int right, T key, Func<T, T, bool> func)
        {
            int middle;
            while (left < right)
            {
                middle = left + ((right - left + 1) >> 1);

                if (func(array[middle], key))
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle;
                }
            }
            return func(array[left], key) ? left : left + 1;
        }
    }
}
