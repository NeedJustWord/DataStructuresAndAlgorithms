using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 归并排序
    /// <para>归并排序算法完全遵循分治模式。直观上其操作如下：</para>
    /// <para>分解：分解待排序的n个元素的序列成各具n/2个元素的两个子序列。</para>
    /// <para>解决：使用归并排序递归地排序两个子序列。</para>
    /// <para>合并：合并两个已排序的子序列以产生已排序的答案。</para>
    /// <para>当待排序的序列长度为1时，递归“开始回升”，在这种情况下不要做任何工作，因为长度为1的每个序列都已排好序。</para>
    /// <para>时间复杂度：最好情况：O(n*log2n)，最坏情况：O(n*log2n)</para>
    /// <para>稳定性：稳定</para>
    /// </summary>
    public class MergeSort : BaseSort
    {
        protected override void SortInternal<T>(T[] array, int left, int right, bool sortAsc)
        {
            var func = GetFunc<T>(sortAsc);
            Sort(array, left, right, func);
        }

        private void Sort<T>(T[] array, int left, int right, Func<T, T, bool> func)
        {
            if (left < right)
            {
                int middle = left + ((right - left) >> 1);
                //排序左半边
                Sort(array, left, middle, func);
                //排序右半边
                Sort(array, middle + 1, right, func);
                //左右归并
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
    }
}
