using System;
using DataStructuresAndAlgorithms.Algorithms.Sort;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ISort sort = new InsertionSort();
            int[] array = InitIntArray();
            SortAsc(sort, array);

            array = InitIntArray();
            SortDesc(sort, array);

            Console.WriteLine("按任意键退出!");
            Console.ReadKey();
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
}
