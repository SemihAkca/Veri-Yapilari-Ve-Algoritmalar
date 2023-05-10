using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList.Doubly;
using Queue.Contrats;

namespace Queue
{
    public class LinkedListQueueDoubly<T>:IQueue<T>
    {
        private DoublyLinkedList<T> _innerList;

        public LinkedListQueueDoubly()
        {
            _innerList = new DoublyLinkedList<T>();
        }

        public LinkedListQueueDoubly(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                EnQueue(item);
            }
        }
        public int Count => _innerList.Count;
        public void EnQueue(T item)
        {
            _innerList.AddLast(item);
        }

        public T DeQueue()
        {
            if (_innerList.Head is null)
            {
                throw new Exception("The queue is empty!");
            }

            return _innerList.RemoveFirst();
        }

        public T Peek()
        {
            return _innerList.Head is null
                ? default(T)
                : _innerList.Head.Value;
        }
    }
}
