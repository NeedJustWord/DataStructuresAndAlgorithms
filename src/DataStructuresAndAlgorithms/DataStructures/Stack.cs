using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Stack<T>
    {
        private T[] array;
        private const int defaultCapacity = 4;
        private static T[] emptyArray = new T[0];

        /// <summary>
        /// 栈中元素的数量
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 栈是否为空
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// 初始化一个初始容量为0的空栈
        /// </summary>
        public Stack()
        {
            array = emptyArray;
        }

        /// <summary>
        /// 初始化一个初始容量为<paramref name="capacity"/>的空栈
        /// </summary>
        /// <param name="capacity"></param>
        public Stack(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "不能小于0");

            array = new T[capacity];
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (Count == array.Length)
            {
                T[] newArray = new T[(Count == 0) ? defaultCapacity : (2 * Count)];
                Array.Copy(array, 0, newArray, 0, Count);
                array = newArray;
            }

            array[Count++] = item;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("栈为空");

            return array[--Count];
        }

        /// <summary>
        /// 查看栈顶元素
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("栈为空");

            return array[Count - 1];
        }
    }
}
