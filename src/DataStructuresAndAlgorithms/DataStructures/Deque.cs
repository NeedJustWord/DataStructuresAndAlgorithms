using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 双端队列
    /// <para>插入和删除操作都可以在两端进行的队列</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Deque<T>
    {
        private T[] array;
        private int head;
        private int tail;
        private const int MinGrow = 4;
        private const int GrowFactor = 200;
        private static T[] emptyArray = new T[0];
        //private const int defaultCapacity = 4;

        /// <summary>
        /// 队列中元素的数量
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// 初始化一个具有默认初始容量的空双端队列
        /// </summary>
        public Deque()
        {
            array = emptyArray;
        }

        /// <summary>
        /// 初始化一个初始容量为<paramref name="capacity"/>的空双端队列
        /// </summary>
        /// <param name="capacity">初始容量</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Deque(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "不能小于0");

            array = new T[capacity];
        }

        /// <summary>
        /// 将对象添加到队首
        /// </summary>
        /// <param name="item"></param>
        public void EnqueueHead(T item)
        {
            if (Count == array.Length)
            {
                CapacityExpansion();
            }

            head = (head - 1 + array.Length) % array.Length;
            array[head] = item;
            Count++;
        }

        /// <summary>
        /// 将对象添加到队尾
        /// </summary>
        /// <param name="item"></param>
        public void EnqueueTail(T item)
        {
            if (Count == array.Length)
            {
                CapacityExpansion();
            }

            array[tail] = item;
            tail = (tail + 1) % array.Length;
            Count++;
        }

        /// <summary>
        /// 移除并返回队首对象
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public T DequeueHead()
        {
            if (Count == 0) throw new InvalidOperationException("队列为空");

            T result = array[head];
            array[head] = default;   // 防止继续引用对象
            head = (head + 1) % array.Length;
            Count--;
            return result;
        }

        /// <summary>
        /// 移除并返回队尾对象
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public T DequeueTail()
        {
            if (Count == 0) throw new InvalidOperationException("队列为空");

            tail = (tail - 1 + array.Length) % array.Length;
            T result = array[tail];
            array[tail] = default;   // 防止继续引用对象
            Count--;
            return result;
        }

        /// <summary>
        /// 返回队首对象而不将其移除
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public T PeekHead()
        {
            if (Count == 0) throw new InvalidOperationException("队列为空");

            return array[head];
        }

        /// <summary>
        /// 返回队尾对象而不将其移除
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public T PeekTail()
        {
            if (Count == 0) throw new InvalidOperationException("队列为空");

            return array[(tail - 1 + array.Length) % array.Length];
        }

        /// <summary>
        /// 扩容
        /// </summary>
        private void CapacityExpansion()
        {
            int num = (int)(array.LongLength * GrowFactor / 100);
            if (num < array.Length + MinGrow)
            {
                num = array.Length + MinGrow;
            }
            SetCapacity(num);
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
