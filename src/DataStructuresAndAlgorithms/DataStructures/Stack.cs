using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 栈
    /// <para>后进先出(LIFO)的集合</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
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
        /// 初始化一个具有默认初始容量的空栈
        /// </summary>
        public Stack()
        {
            array = emptyArray;
        }

        /// <summary>
        /// 初始化一个初始容量为<paramref name="capacity"/>的空栈
        /// </summary>
        /// <param name="capacity">初始容量</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Stack(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "不能小于0");

            array = new T[capacity];
        }

        /// <summary>
        /// 在栈顶插入一个对象
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
        /// 移除并返回栈顶对象
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("栈为空");

            T result = array[--Count];
            array[Count] = default;   // 防止继续引用对象
            return result;
        }

        /// <summary>
        /// 返回栈顶对象而不将其移除
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("栈为空");

            return array[Count - 1];
        }
    }
}
