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
    /// <para>稳定性：稳定</para>
    /// </summary>
    public class InsertionSort : BaseSort
    {
        protected override void SortInternal<T>(T[] array, int left, int right, bool sortAsc)
        {
            var func = GetFunc<T>(sortAsc);
            T key;
            int i;

            for (int j = left + 1; j <= right; j++)
            {
                key = array[j];
                //将array[j]插入到已排好序的序列array[left...j-1]
                for (i = j - 1; i >= left && func(array[i], key); i--)
                {
                    array[i + 1] = array[i];
                }
                array[i + 1] = key;
            }
        }
    }
}
