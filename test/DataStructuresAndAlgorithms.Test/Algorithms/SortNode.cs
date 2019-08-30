using System;

namespace DataStructuresAndAlgorithms.Test.Algorithms
{
    class SortNode : IComparable<SortNode>
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public SortNode(int id, int value)
        {
            Id = id;
            Value = value;
        }

        public int CompareTo(SortNode other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
