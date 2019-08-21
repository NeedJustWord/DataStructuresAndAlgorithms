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
        public BinaryTreeNode<T> Parent { get; set; }

        /// <summary>
        /// 左子树
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// 右子树
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }
    }
}
