using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Doubly
{
    public class DoublyLinkedList<T>:IEnumerable<T>
    {
        public DbNode<T> Head;
        public DbNode<T> Tail;
        private int _count;
        public int Count => _count;

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            _count = 0;
        }

        public DoublyLinkedList(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        public void AddFirst(T item)
        {
            var node = new DbNode<T>(item);

            if (Head is null)
            {
                Head = node;
                Tail = node;
                _count++;
                return;
            }
            node.Next = Head;
            Head.Prev = node;
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
            var newNode = new DbNode<T>(item);
            var current = Head;
            var prev = current;
            while (current != null)
            {
                prev = current;
                current = current.Next;
            }
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            _count++;
        }

        public void AddBefore(DbNode<T> node,T item)
        {
            if (node is  null || item is null)
            {
                throw new ArgumentNullException();
            }
            if (Head is null)
            {
                AddFirst(item);
                return;
            }
            var newNode = new DbNode<T>(item);
            var current = Head;
            var prev = current;
            while (current!= null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    newNode.Prev = prev;
                    prev.Next = newNode;
                    _count++;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new Exception(nameof(node));
        }

        public void AddAfter(DbNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
                return;
            }

            var newNode = new DbNode<T>(item);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    current.Next = newNode;
                    newNode.Next.Prev = newNode;
                    _count++;
                    return;
                }
                current = current.Next;
            }
            throw new Exception(nameof(node));
        }

        public T RemoveFirst()
        {
            if (Head is null)
            {
                throw new ArgumentNullException(nameof(Head));
            }
            var temp = Head;
            Head = Head.Next;
            Head.Prev = null;
            _count--;
            return temp.Value;
        }

        public T RemoveLast()
        {
            if (Head is null)
            {
                throw new ArgumentNullException(nameof(Head));
            }
            var temp = Tail;
            Tail.Prev.Next = null;
            Tail = Tail.Prev;
            _count--;
            return temp.Value;
        }

        public T Remove(T item)
        {
            if (Head is null)
            {
                throw new ArgumentNullException(nameof(Head));
            }

            var current = Head;
            var prev = current;
            while (current!= null)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Value.Equals(Head.Value))
                    {
                        RemoveFirst();
                    }

                    if (current.Value.Equals(Tail.Value))
                    {
                        RemoveLast();
                    }
                    var temp = current;
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
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
            return new DoublyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
