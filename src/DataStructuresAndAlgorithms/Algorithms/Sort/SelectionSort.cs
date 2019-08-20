using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 选择排序
    /// <para>从头至尾扫描序列，选出关键元素(最大或最小)，和第一个元素交换。</para>
    /// <para>接着从剩下的元素中继续这种选择和交换方式，最终得到一个有序序列。</para>
    /// <para>因为两个元素才有交换一说，所以最后剩下一个元素的时候不需要再继续选择排序了。</para>
    /// <para>时间复杂度：最好情况：O(n^2)，最坏情况：O(n^2)</para>
    /// <para>稳定性：不稳定</para>
    /// </summary>
    public class SelectionSort : BaseSort
    {
        protected override void Sort<T>(T[] array, Func<T, T, bool> func)
        {
            T temp;
            int j, keyIndex, lastIndex = array.Length - 1;

            for (int i = 0; i < lastIndex; i++)
            {
                //在待排序序列[i...n-1]里找出关键元素(最大或最小)的下标
                keyIndex = i;
                for (j = i + 1; j < array.Length; j++)
                {
                    if (func(array[keyIndex], array[j]))
                    {
                        keyIndex = j;
                    }
                }

                //将关键元素放到待排序序列的首位
                if (keyIndex != i)
                {
                    temp = array[keyIndex];
                    array[keyIndex] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}
