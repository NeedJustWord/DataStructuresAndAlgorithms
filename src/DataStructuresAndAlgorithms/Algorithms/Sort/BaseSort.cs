﻿using System;

namespace DataStructuresAndAlgorithms.Algorithms.Sort
{
    /// <summary>
    /// 排序抽象类
    /// </summary>
    public abstract class BaseSort : ISort
    {
        public void Sort<T>(T[] array, bool sortAsc) where T : IComparable<T>
        {
            if (sortAsc)
            {
                Sort(array, Asc);
            }
            else
            {
                Sort(array, Desc);
            }
        }

        protected abstract void Sort<T>(T[] array, Func<T, T, bool> func) where T : IComparable<T>;

        /// <summary>
        /// 判断<paramref name="t1"/>是否比<paramref name="t2"/>大
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        private bool Asc<T>(T t1, T t2) where T : IComparable<T>
        {
            return t1.CompareTo(t2) > 0;
        }

        /// <summary>
        /// 判断<paramref name="t1"/>是否比<paramref name="t2"/>小
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        private bool Desc<T>(T t1, T t2) where T : IComparable<T>
        {
            return t1.CompareTo(t2) < 0;
        }
    }
}
