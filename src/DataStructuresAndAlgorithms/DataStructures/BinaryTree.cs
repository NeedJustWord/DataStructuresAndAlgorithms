using System;

namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 二叉树
    /// <para>每个结点最多有两个子树的树结构</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BinaryTree<T>
    {
        /// <summary>
        /// 根节点
        /// </summary>
        public BinaryTreeNode<T> Root { get; protected set; }

        #region 构造函数
        /// <summary>
        /// 创建一棵空二叉树
        /// </summary>
        protected BinaryTree()
        {
        }

        /// <summary>
        /// 创建一棵根节点为<paramref name="data"/>的二叉树
        /// </summary>
        /// <param name="data"></param>
        protected BinaryTree(T data)
        {
            Root = new BinaryTreeNode<T>(data);
        }
        #endregion

        #region 遍历

        #region 前序遍历
        /// <summary>
        /// 前序遍历，也叫先根遍历，先序遍历
        /// <para>根左右</para>
        /// </summary>
        /// <param name="action"></param>
        public void Preorder(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var stack = new System.Collections.Generic.Stack<BinaryTreeNode<T>>();
            if (Root != null)
            {
                stack.Push(Root);
            }

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                action(current.Data);

                //栈是后进先出，所以先使用的左节点要后入栈
                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
        }

        /// <summary>
        /// 前序遍历递归版本
        /// <para>根左右</para>
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void PreorderRecursive(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            PreorderRecursive(Root, action);
        }

        private void PreorderRecursive(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                action(node.Data);
                PreorderRecursive(node.Left, action);
                PreorderRecursive(node.Right, action);
            }
        }
        #endregion

        #region 中序遍历
        /// <summary>
        /// 中序遍历，也叫中根遍历
        /// <para>左根右</para>
        /// </summary>
        /// <param name="action"></param>
        public void Inorder(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            //todo:
        }

        /// <summary>
        /// 中序遍历递归版本
        /// <para>左根右</para>
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void InorderRecursive(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            InorderRecursive(Root, action);
        }

        private void InorderRecursive(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                InorderRecursive(node.Left, action);
                action(node.Data);
                InorderRecursive(node.Right, action);
            }
        }
        #endregion

        #region 后续遍历
        /// <summary>
        /// 后序遍历，也叫后根遍历
        /// <para>左右根</para>
        /// </summary>
        /// <param name="action"></param>
        public void Postorder(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            //todo:
        }

        /// <summary>
        /// 后序遍历递归版本
        /// <para>左右根</para>
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void PostorderRecursive(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            PostorderRecursive(Root, action);
        }

        private void PostorderRecursive(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                PostorderRecursive(node.Left, action);
                PostorderRecursive(node.Right, action);
                action(node.Data);
            }
        }
        #endregion

        #region 层序遍历
        /// <summary>
        /// 层序遍历
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void LevelOrder(Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var queue = new System.Collections.Generic.Queue<BinaryTreeNode<T>>();
            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            BinaryTreeNode<T> item;
            while (queue.Count != 0)
            {
                item = queue.Dequeue();
                action(item.Data);

                if (item.Left != null)
                {
                    queue.Enqueue(item.Left);
                }
                if (item.Right != null)
                {
                    queue.Enqueue(item.Right);
                }
            }
        }
        #endregion

        #endregion
    }
}
