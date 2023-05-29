using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree(Node<T> node)
        {
            Root = node;
        }

        public BinarySearchTree(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            var newNode = new Node<T>(item);
            if (Root is null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    if (item.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        // Recursive 
        public void PreOrder(Node<T> root,List<T> list) // Root - Left - Right 
        {
            if (root == null) {return;}

            list.Add(root.Value);
            PreOrder(root.Left,list);
            PreOrder(root.Right,list);
        }
        public void InOrder(Node<T> root,List<T> list) // Left - Root - Right
        {
            if (root != null)
            {
                InOrder(root.Left,list);
                list.Add(root.Value);
                InOrder(root.Right,list);
            }
        }

        public void PostOrder(Node<T> root,List<T> list) // Left - Right - Root
        {
            if (root is null) { return; }
            PostOrder(root.Left,list);
            PostOrder(root.Right,list);
            list.Add(root.Value);
        }

        // Iterative
        public void PreOrderIterative(Node<T> root,List<T> list)
        {
            if (root == null)
                return;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                Node<T> node = stack.Pop();
                list.Add(node.Value);

                if (root.Right != null)
                {
                    stack.Push(root.Right);
                }

                if (root.Left != null)
                {
                    stack.Push(root.Left);
                }
            }
        }

        public void InOrderIterative(Node<T> root, List<T> list)
        {
            if (root == null)
                return;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> node = root;
            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    list.Add(node.Value);
                    node = node.Right;
                }
            }
        }

        public void PostOrderIterative(Node<T> root, List<T> list)
        {
            if (root == null)
                return;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> node = root;
            Node<T> node2 = null;
            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Peek();
                    if (node.Right == null)
                    {
                        list.Add(node.Value);
                        stack.Pop();
                        node2 = node;
                        node = null;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
        }
    }
}
