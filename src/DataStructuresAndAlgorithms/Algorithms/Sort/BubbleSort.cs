namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 冒泡排序
    /// <para>反复交换相邻的未按次序排列的元素。</para>
    /// <para>时间复杂度：最好情况：O(n^2)，最坏情况：O(n^2)</para>
    /// <para>稳定性：稳定</para>
    /// </summary>
    public class BubbleSort : BaseSort
    {
        protected override void SortInternal<T>(T[] array, int left, int right, bool sortAsc)
        {
            var func = GetFunc<T>(sortAsc);
            for (int i = left; i < right; i++)
            {
                for (int j = right; j > i; j--)
                {
                    if (func(array[j - 1], array[j]))
                    {
                        Exchange(array, j - 1, j);
                    }
                }
            }
        }

        private void Exchange<T>(T[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
