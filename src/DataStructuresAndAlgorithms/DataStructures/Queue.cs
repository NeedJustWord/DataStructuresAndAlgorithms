using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Queue<T>
    {
        private T[] array;
        private int head;
        private int tail;
        private const int MinGrow = 4;
        private const int GrowFactor = 200;
        private const int defaultCapacity = 4;
        private static T[] emptyArray = new T[0];

        /// <summary>
        /// 队列中元素的数量
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// 初始化一个容量为0的队列
        /// </summary>
        public Queue()
        {
            array = emptyArray;
        }

        /// <summary>
        /// 初始化一个容量为<paramref name="capacity"/>的队列
        /// </summary>
        /// <param name="capacity"></param>
        public Queue(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "不能小于0");

            array = new T[capacity];
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (Count == array.Length)
            {
                int num = (int)(array.LongLength * GrowFactor / 100);
                if (num < array.Length + MinGrow)
                {
                    num = array.Length + MinGrow;
                }
                SetCapacity(num);
            }

            array[tail] = item;
            tail = (tail + 1) % array.Length;
            Count++;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("队列为空");

            T result = array[head];
            head = (head + 1) % array.Length;
            Count--;
            return result;
        }

        /// <summary>
        /// 查看队首元素
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("队列为空");

            return array[head];
        }

        private void SetCapacity(int capacity)
        {
            T[] newArray = new T[capacity];
            if (Count > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newArray, 0, Count);
                }
                else
                {
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                }
            }

            array = newArray;
            head = 0;
            tail = (Count == capacity) ? 0 : Count;
        }
    }
}
