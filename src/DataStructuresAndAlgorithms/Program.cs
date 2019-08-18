using System;
using DataStructuresAndAlgorithms.Algorithms.Sort;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 5, 2, 4, 6, 1, 3 };
            Print(true, array);

            ISort sort = new InsertionSort();
            sort.Sort(array);

            Print(false, array);

            Console.WriteLine("按任意键退出!");
            Console.ReadKey();
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
