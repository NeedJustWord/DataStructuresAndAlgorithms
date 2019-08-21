namespace DataStructuresAndAlgorithms.DataStructures
{
    /// <summary>
    /// 二叉树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class BinaryTreeNode<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public BinaryTreeNode<T> Parent { get; private set; }
        /// <summary>
        /// 左子树
        /// </summary>
        public BinaryTreeNode<T> Left { get; private set; }
        /// <summary>
        /// 右子树
        /// </summary>
        public BinaryTreeNode<T> Right { get; private set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public BinaryTreeNode(BinaryTreeNode<T> parent, T data)
        {
            Parent = parent;
            Data = data;
        }

        /// <summary>
        /// 设置左节点数据，返回自身
        /// </summary>
        /// <param name="data">左节点数据</param>
        /// <returns></returns>
        public BinaryTreeNode<T> SetLeftData(T data)
        {
            if (Left == null)
            {
                Left = new BinaryTreeNode<T>(this, data);
            }
            else
            {
                Left.Data = data;
            }
            return this;
        }

        /// <summary>
        /// 设置右节点数据，返回自身
        /// </summary>
        /// <param name="data">右节点数据</param>
        /// <returns></returns>
        public BinaryTreeNode<T> SetRightData(T data)
        {
            if (Right == null)
            {
                Right = new BinaryTreeNode<T>(this, data);
            }
            else
            {
                Right.Data = data;
            }
            return this;
        }
    }
}
