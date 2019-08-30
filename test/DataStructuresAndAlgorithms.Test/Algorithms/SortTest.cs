using System;
using DataStructuresAndAlgorithms.Algorithms.Sort;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.Algorithms
{
    public class SortTest
    {
        private SortNode[] array;

        public SortTest()
        {
            array = GetRandomArray();
        }

        #region 插入排序测试用例
        [Fact]
        public void InsertionSortAscTest()
        {
            bool sortAsc = true;
            var copyArray = CopyArray();
            var sort = new InsertionSort();
            sort.Sort(copyArray, sortAsc);

            bool flag = CheckArray(copyArray, sortAsc, true);
            Assert.True(flag);
        }

        [Fact]
        public void InsertionSortDescTest()
        {
            bool sortAsc = false;
            var copyArray = CopyArray();
            var sort = new InsertionSort();
            sort.Sort(copyArray, sortAsc);

            bool flag = CheckArray(copyArray, sortAsc, true);
            Assert.True(flag);
        }
        #endregion

        #region 选择排序测试用例
        [Fact]
        public void SelectionSortAscTest()
        {
            bool sortAsc = true;
            var copyArray = CopyArray();
            var sort = new SelectionSort();
            sort.Sort(copyArray, sortAsc);

            bool flag = CheckArray(copyArray, sortAsc, false);
            Assert.True(flag);
        }

        [Fact]
        public void SelectionSortDescTest()
        {
            bool sortAsc = false;
            var copyArray = CopyArray();
            var sort = new SelectionSort();
            sort.Sort(copyArray, sortAsc);

            bool flag = CheckArray(copyArray, sortAsc, false);
            Assert.True(flag);
        }
        #endregion

        #region 归并排序测试用例
        [Fact]
        public void MergeSortAscTest()
        {
            bool sortAsc = true;
            var copyArray = CopyArray();
            var sort = new MergeSort();
            sort.Sort(copyArray, sortAsc);

            bool flag = CheckArray(copyArray, sortAsc, true);
            Assert.True(flag);
        }

        [Fact]
        public void MergeSortDescTest()
        {
            bool sortAsc = false;
            var copyArray = CopyArray();
            var sort = new MergeSort();
            sort.Sort(copyArray, sortAsc);

            bool flag = CheckArray(copyArray, sortAsc, true);
            Assert.True(flag);
        }
        #endregion

        #region 私有方法
        private bool CheckArray(SortNode[] array, bool sortAsc, bool isStable)
        {
            if (isStable)
            {
                return sortAsc ? IsStableAsc(array) : IsStableDesc(array);
            }
            else
            {
                return sortAsc ? IsAsc(array) : IsDesc(array);
            }
        }

        private bool IsAsc(SortNode[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Value < array[i - 1].Value)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsDesc(SortNode[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Value > array[i - 1].Value)
                {
                    return false;
                }
            }
            return true;
        }


        private bool IsStableAsc(SortNode[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Value < array[i - 1].Value)
                {
                    return false;
                }
                else if (array[i].Value == array[i - 1].Value && array[i].Id < array[i - 1].Id)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsStableDesc(SortNode[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Value > array[i - 1].Value)
                {
                    return false;
                }
                else if (array[i].Value == array[i - 1].Value && array[i].Id < array[i - 1].Id)
                {
                    return false;
                }
            }
            return true;
        }

        private SortNode[] CopyArray()
        {
            var result = new SortNode[array.Length];
            Array.Copy(array, 0, result, 0, array.Length);
            return result;
        }

        private SortNode[] GetRandomArray()
        {
            SortNode[] nums = new SortNode[10000];
            int value;
            for (int i = 0; i < nums.Length; i++)
            {
                value = GetRandomNumber(0, 10000);
                nums[i] = new SortNode(i, value);
            }
            return nums;
        }

        private int GetRandomNumber(int minValue, int maxValue)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(minValue, maxValue);
        }
        #endregion
    }
}
