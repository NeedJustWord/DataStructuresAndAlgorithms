using System;
using DataStructuresAndAlgorithms.Algorithms.Sort;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ISort sort = GetSort(SortType.Merge);
            int[] array = InitIntArray();
            SortAsc(sort, array);

            array = InitIntArray();
            SortDesc(sort, array);

            Console.WriteLine("按任意键退出!");
            Console.ReadKey();
        }

        static ISort GetSort(SortType sortType)
        {
            switch (sortType)
            {
                case SortType.Insertion:
                    Console.WriteLine("插入排序");
                    return new InsertionSort();
                case SortType.Selection:
                    Console.WriteLine("选择排序");
                    return new SelectionSort();
                case SortType.Merge:
                    Console.WriteLine("归并排序");
                    return new MergeSort();
            }
            throw new NotImplementedException();
        }

        static void SortAsc<T>(ISort sort, T[] array) where T : IComparable<T>
        {
            Console.WriteLine("按升序排");
            Print(true, array);
            sort.Sort(array, true);
            Print(false, array);
            Console.WriteLine();
        }

        static void SortDesc<T>(ISort sort, T[] array) where T : IComparable<T>
        {
            Console.WriteLine("按降序排");
            Print(true, array);
            sort.Sort(array, false);
            Print(false, array);
            Console.WriteLine();
        }

        static int[] InitIntArray()
        {
            return new int[] { 5, 2, 4, 6, 1, 3 };
        }

        static void Print<T>(bool befortSort, T[] array)
        {
            Console.Write(befortSort ? "排序前：" : "排序后：");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }

    enum SortType
    {
        Insertion,
        Selection,
        Merge,
    }
}
