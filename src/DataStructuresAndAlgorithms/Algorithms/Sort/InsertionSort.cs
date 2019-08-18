using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 插入排序：对于少量元素的排序，它是一个有效的算法
    /// <para>插入排序的工作方式像许多人排序一手扑克牌。</para>
    /// <para>开始时，我们的左手为空并且桌子上的牌面向下。</para>
    /// <para>然后，我们每次从桌子上拿走一张牌并将它插入左手中正确的位置。</para>
    /// <para>为了找到一张牌的正确位置，我们从右到左将它与已在手中的每张牌进行比较。</para>
    /// <para>拿在左手上的牌总是排序好的，原来这些牌是桌子上牌堆中顶部的牌。</para>
    /// <para>时间复杂度：最好情况：O(n)，最坏情况：O(n^2)</para>
    /// </summary>
    class InsertionSort : BaseSort
    {
        public override void Sort<T>(T[] array, bool sortAsc)
        {
            T key;
            int i;
            var func = sortAsc ? (Func<T, T, bool>)Asc : Desc;

            for (int j = 1; j < array.Length; j++)
            {
                key = array[j];
                //将array[j]插入到已排好序的序列array[0...j-1]
                i = j - 1;
                while (i > -1 && func(array[i], key))
                {
                    array[i + 1] = array[i];
                    i -= 1;
                }
                array[i + 1] = key;
            }
        }
    }
}
