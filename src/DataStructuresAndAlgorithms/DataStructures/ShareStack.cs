using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 共享栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ShareStack<T>
    {
        private T[] array;
        private const int defaultCapacity = 4;
        private static T[] emptyArray = new T[0];

        /// <summary>
        /// 栈1中元素的数量
        /// </summary>
        public int Count1 { get; private set; }

        /// <summary>
        /// 栈2中元素的数量
        /// </summary>
        public int Count2 { get; private set; }

        /// <summary>
        /// 栈1是否为空
        /// </summary>
        public bool IsEmpty1 => Count1 == 0;

        /// <summary>
        /// 栈2是否为空
        /// </summary>
        public bool IsEmpty2 => Count2 == 0;

        public ShareStack()
        {
            array = emptyArray;
        }

        public ShareStack(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "不能小于0");

            array = new T[capacity];
        }

        /// <summary>
        /// 入栈1
        /// </summary>
        /// <param name="item"></param>
        public void Push1(T item)
        {
            if (Count1 + Count2 == array.Length)
            {
                int num = (array.Length == 0) ? defaultCapacity : (2 * array.Length);
                SetCapacity(num);
            }

            array[Count1++] = item;
        }

        /// <summary>
        /// 入栈2
        /// </summary>
        /// <param name="item"></param>
        public void Push2(T item)
        {
            if (Count1 + Count2 == array.Length)
            {
                int num = (array.Length == 0) ? defaultCapacity : (2 * array.Length);
                SetCapacity(num);
            }

            array[array.Length - 1 - Count2] = item;
            Count2++;
        }

        /// <summary>
        /// 出栈1
        /// </summary>
        /// <returns></returns>
        public T Pop1()
        {
            if (Count1 == 0) throw new InvalidOperationException("栈1为空");

            return array[--Count1];
        }

        public T Pop2()
        {
            if (Count2 == 0) throw new InvalidOperationException("栈2为空");

            T result = array[array.Length - Count2];
            Count2--;
            return result;
        }

        public T Peek1()
        {
            if (Count1 == 0) throw new InvalidOperationException("栈1为空");

            return array[Count1 - 1];
        }

        public T Peek2()
        {
            if (Count2 == 0) throw new InvalidOperationException("栈2为空");

            return array[array.Length - Count2];
        }

        private void SetCapacity(int capacity)
        {
            T[] newArray = new T[capacity];
            if (Count1 > 0)
            {
                Array.Copy(array, 0, newArray, 0, Count1);
            }
            if (Count2 > 0)
            {
                Array.Copy(array, array.Length - Count2, newArray, newArray.Length - Count2, Count2);
            }

            array = newArray;
        }
    }
}
