namespace BinarySearchTree
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public bool IsLeaf => (Left == null && Right == null);

        public Node()
        {
            
        }
        public Node(T item)
        {
            Value = item;
        }

        public override string ToString() { return $"{Value}"; }
    }
}