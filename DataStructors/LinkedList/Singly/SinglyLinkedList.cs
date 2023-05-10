using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Singly
{
    public class SinglyLinkedList<T>:IEnumerable<T>
    {
        private int _count;
        public SinglyLinkedListNode<T> Head { get; set; }
        public int Count => _count;

        public SinglyLinkedList()
        {
            _count = 0;
        }

        public SinglyLinkedList(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        public void AddFirst(T item)
        {
            var node = new SinglyLinkedListNode<T>(item);
            if (Head is null)
            {
                Head = node;
                _count++;
                return;
            }
            node.Next = Head;
            Head = node;
            _count++;
        }

        public void AddLast(T item)
        {
            if (Head is null)
            {
                AddFirst(item);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(item);
            var current = Head;
            var prev = current;
            while (current!= null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = newNode;
            _count++;
        }

        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
            }

            var newNode = new SinglyLinkedListNode<T>(item);
            var current = Head;
            var prev = current;
            while (current!= null)
            {
                if (current.Equals(node))
                {
                    prev.Next = newNode;
                    newNode.Next = current;
                    _count++;
                    return;
                }
                prev = current;
                current = current.Next;
            }

            throw new Exception("The node is not found in the linkedList");
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
            }

            var newNode = new SinglyLinkedListNode<T>(item);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    _count++;
                    return;
                }
                current = current.Next;
            }
    
            throw new Exception("The node is not found in the linkedList");
        }

        public T RemoveFirst()
        {
            if (Head is null)
            {
                throw new ArgumentNullException(nameof(Head));
            }
            var temp = Head;
            Head = Head.Next;
            _count--;
            return temp.Value;
        }

        public T RemoveLast()
        {
            if (Head is null)
            {
                throw new ArgumentNullException(nameof(Head));
            }
            
            var current = Head;
            var prev = current;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }

            if (current.Equals(Head))
            {
                var temp = Head;
                Head = null;
                _count--;
                return temp.Value;
            }
            prev.Next = null;
            _count--;
            return current.Value;
        }

        public T Remove(T item)
        {
            if (Head is null)
            {
                throw new ArgumentNullException(nameof(Head));
            }

            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (item.Equals(Head.Value))
                {
                    RemoveFirst();
                }

                if (current.Value.Equals(item))
                {
                    var temp = current;
                    prev.Next = current.Next;
                    current = null;
                    _count--;
                    return temp.Value;
                }
                prev = current;
                current = current.Next;
            }

            throw new Exception("The item is not found in the linkedList");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
