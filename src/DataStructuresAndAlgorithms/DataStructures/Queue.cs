﻿using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 队列
    /// <para>先进先出(FIFO)的集合</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
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
        /// 初始化一个具有默认初始容量的空队列
        /// </summary>
        public Queue()
        {
            array = emptyArray;
        }

        /// <summary>
        /// 初始化一个初始容量为<paramref name="capacity"/>的空队列
        /// </summary>
        /// <param name="capacity">初始容量</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Queue(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "不能小于0");

            array = new T[capacity];
        }

        /// <summary>
        /// 将对象添加到队尾
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
        /// 移除并返回队首对象
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("队列为空");

            T result = array[head];
            array[head] = default;   // 防止继续引用对象
            head = (head + 1) % array.Length;
            Count--;
            return result;
        }

        /// <summary>
        /// 返回队首对象而不将其移除
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
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
