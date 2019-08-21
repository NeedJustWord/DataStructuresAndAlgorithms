using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 二叉搜索树
    /// <para>对每个结点，左节点不大于它，右节点不小于它</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        #region 构造函数
        public BinarySearchTree() : base()
        {
        }

        public BinarySearchTree(T data) : base(data)
        {
        }
        #endregion

        #region 搜索
        /// <summary>
        /// 递归搜索
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTreeNode<T> SearchRecursive(T data)
        {
            return SearchRecursive(Root, data);
        }

        private BinaryTreeNode<T> SearchRecursive(BinaryTreeNode<T> x, T k)
        {
            if (x == null) return null;
            var result = k.CompareTo(x.Data);
            if (result == 0) return x;
            else if (result < 0) return SearchRecursive(x.Left, k);
            else return SearchRecursive(x.Right, k);
        }
        #endregion

        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data)
        {
            Insert(new BinaryTreeNode<T>(data));
        }

        private void Insert(BinaryTreeNode<T> z)
        {
            BinaryTreeNode<T> y = null;
            var x = Root;
            while (x != null)
            {
                y = x;
                if (z.Data.CompareTo(x.Data) < 0) x = x.Left;
                else x = x.Right;
            }
            z.Parent = y;
            if (y == null) Root = z;
            else if (z.Data.CompareTo(y.Data) < 0) y.Left = z;
            else y.Right = z;
        }
        #endregion
    }
}
