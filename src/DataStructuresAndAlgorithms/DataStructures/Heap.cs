using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 堆
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T> where T : IComparable<T>
    {
        private T[] array;
        private int heapSize;
        private Func<T, T, bool> func;
        private const int defaultCapacity = 3;
        private static T[] emptyArray = new T[0];

        /// <summary>
        /// 初始化一个具有默认初始容量的空堆
        /// </summary>
        /// <param name="isMaxHeap">true：大根堆，false：小根堆</param>
        public Heap(bool isMaxHeap)
        {
            Init(0, isMaxHeap);
        }

        /// <summary>
        /// 初始化一个初始容量为<paramref name="capacity"/>的空堆
        /// </summary>
        /// <param name="capacity">初始容量</param>
        /// <param name="isMaxHeap">true：大根堆，false：小根堆</param>
        public Heap(int capacity, bool isMaxHeap)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "不能小于0");

            Init(capacity, isMaxHeap);
        }

        /// <summary>
        /// 使用<paramref name="array"/>初始化堆
        /// </summary>
        /// <param name="array"></param>
        /// <param name="isMaxHeap">true：大根堆，false：小根堆</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Heap(T[] array, bool isMaxHeap)
        {
            if (array == null) throw new ArgumentNullException(nameof(array), "不能为null");

            Init(array.Length, isMaxHeap);
            BuildHeap(array);
        }

        #region 建堆
        /// <summary>
        /// 使用给定数组<paramref name="array"/>建堆
        /// </summary>
        /// <param name="array"></param>
        public void BuildHeap(T[] array)
        {
            heapSize = array.Length;
            EnsureCapacity(heapSize, false);
            Array.Copy(array, 0, this.array, 1, heapSize);
            BuildHeap();
        }

        private void BuildHeap()
        {
            for (int i = heapSize >> 1; i > 0; i--)
            {
                Heapify(i);
            }
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="isMaxHeap"></param>
        private void Init(int capacity, bool isMaxHeap)
        {
            array = capacity == 0 ? emptyArray : new T[capacity + 1];
            func = isMaxHeap ? (Func<T, T, bool>)Max : Min;
        }

        /// <summary>
        /// 确保array数组弄容纳<paramref name="capacity"/>个节点
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="copyArray">是否将旧数组复制到新数组</param>
        private void EnsureCapacity(int capacity, bool copyArray)
        {
            if (capacity > array.Length)
            {
                int depth = GetDepth(capacity);
                int num = GetFullNumber(depth);
                if (num < defaultCapacity)
                {
                    num = defaultCapacity;
                }

                var newArray = new T[num + 1];
                if (copyArray) Array.Copy(array, 0, newArray, 0, array.Length);

                array = newArray;
            }
        }

        /// <summary>
        /// 获取<paramref name="n"/>个节点的完全二叉树的深度
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int GetDepth(int n)
        {
            return (int)Math.Floor(Math.Log10(n) / Math.Log10(2)) + 1;
        }

        /// <summary>
        /// 获取深度为<paramref name="depth"/>的满二叉树的总节点数
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        private int GetFullNumber(int depth)
        {
            return (int)Math.Pow(2, depth) - 1;
        }

        #region 维护堆性质
        /// <summary>
        /// 维护堆（最大堆或最小堆）性质
        /// </summary>
        private void Heapify(int index)
        {
            int left;
            int right;
            int target;

            while (true)
            {
                left = GetLeftIndex(index);
                right = GetRightIndex(index);

                //index、left、right中找极值（最大值或最小值）
                if (left <= heapSize && func(array[left], array[index])) target = left;
                else target = index;
                if (right <= heapSize && func(array[right], array[target])) target = right;

                if (target == index)
                {
                    break;
                }

                //index和极值交换
                //交换后需要继续维护堆性质
                Exchange(index, target);
                index = target;
            }
        }

        /// <summary>
        /// 递归维护堆（最大堆或最小堆）性质
        /// </summary>
        private void HeapifyRecursive(int index)
        {
            var left = GetLeftIndex(index);
            var right = GetRightIndex(index);
            int target;

            //index、left、right中找极值（最大值或最小值）
            if (left <= heapSize && func(array[left], array[index])) target = left;
            else target = index;
            if (right <= heapSize && func(array[right], array[target])) target = right;

            if (target != index)
            {
                //index和极值交换
                //交换后需要继续维护堆性质
                Exchange(index, target);
                HeapifyRecursive(target);
            }
        }
        #endregion

        /// <summary>
        /// 交换
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void Exchange(int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        /// <summary>
        /// 获取父节点的下标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetParentIndex(int index) => index / 2;

        /// <summary>
        /// 获取左孩子的下标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetLeftIndex(int index) => 2 * index;

        /// <summary>
        /// 获取右孩子的下标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetRightIndex(int index) => 2 * index + 1;

        private bool Max(T t1, T t2) => t1.CompareTo(t2) > 0;
        private bool Min(T t1, T t2) => t1.CompareTo(t2) < 0;
    }
}
