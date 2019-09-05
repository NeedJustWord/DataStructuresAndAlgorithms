using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 优化版归并排序
    /// <para>优化1：对小数组采用插入排序</para>
    /// <para>优化2：左右两边无序的时候才需要归并</para>
    /// </summary>
    public class OptimizingMergeSort : BaseSort
    {
        private readonly int K;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public OptimizingMergeSort(int k)
        {
            if (k <= 0) throw new ArgumentOutOfRangeException(nameof(k), $"{nameof(k)}不能小于1");

            K = k;
        }

        protected override void SortInternal<T>(T[] array, int left, int right, bool sortAsc)
        {
            var func = GetFunc<T>(sortAsc);
            Sort(array, left, right, func);
        }

        private void Sort<T>(T[] array, int left, int right, Func<T, T, bool> func)
        {
            if (right - left <= K)
            {
                // 优化1：当数组长度小于K时，改用插入排序
                InsertSortInternal(array, left, right, func);
                return;
            }

            int middle = left + ((right - left) >> 1);
            //排序左半边
            Sort(array, left, middle, func);
            //排序右半边
            Sort(array, middle + 1, right, func);

            if (func(array[middle], array[middle + 1]))
            {
                // 优化2：左边最后一个和右边第一个无序才需要归并
                Merge(array, left, middle, right, func);
            }
        }

        private void Merge<T>(T[] array, int left, int middle, int right, Func<T, T, bool> func)
        {
            T[] sort = new T[right - left + 1];
            int i = left, j = middle + 1, k = 0;

            //按顺序移入新数组，直到其中一个数组为空
            while (i <= middle && j <= right)
            {
                if (func(array[i], array[j]))
                {
                    sort[k++] = array[j++];
                }
                else
                {
                    sort[k++] = array[i++];
                }
            }

            //将左边剩余的数移入数组
            while (i <= middle)
            {
                sort[k++] = array[i++];
            }

            //将右边剩余的数移入数组
            while (j <= right)
            {
                sort[k++] = array[j++];
            }

            //将新数组覆盖array的[left,right]
            for (k = 0; k < sort.Length; k++)
            {
                array[left + k] = sort[k];
            }
        }

        private void InsertSortInternal<T>(T[] array, int left, int right, Func<T, T, bool> func)
        {
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
        /// 升序的时候，找到不小于<paramref name="key"/>的最大下标
        /// 降序的时候，找到不大于<paramref name="key"/>的最大下标
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
