using System;
using DataStructuresAndAlgorithms.Algorithms.Sort;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.Algorithms
{
    public class SortTest
    {
        #region 插入排序测试用例
        [Fact]
        public void InsertionSortAscTest()
        {
            bool sortAsc = true;
            var array = GetRandomArray();
            var sort = new InsertionSort();
            sort.Sort(array, sortAsc);

            bool flag = CheckArray(array, sortAsc);
            Assert.True(flag);
        }

        [Fact]
        public void InsertionSortDescTest()
        {
            bool sortAsc = false;
            var array = GetRandomArray();
            var sort = new InsertionSort();
            sort.Sort(array, sortAsc);

            bool flag = CheckArray(array, sortAsc);
            Assert.True(flag);
        }
        #endregion

        private bool CheckArray(int[] array, bool sortAsc)
        {
            return sortAsc ? IsAsc(array) : IsDesc(array);
        }

        private bool IsAsc(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsDesc(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private int[] GetRandomArray()
        {
            int[] nums = new int[100];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = GetRandomNumber(0, 1000);
            }
            return nums;
        }

        private int GetRandomNumber(int minValue, int maxValue)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(minValue, maxValue);
        }
    }
}
