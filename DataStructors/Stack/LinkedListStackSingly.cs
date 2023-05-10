using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList.Singly;
using Stack.Contrats;

namespace Stack
{
    public class LinkedListStackSingly<T>:IStack<T>
    {
        private SinglyLinkedList<T> _innerList;

        public LinkedListStackSingly()
        {
            _innerList = new SinglyLinkedList<T>();
        }

        public LinkedListStackSingly(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }
        public int Count => _innerList.Count;
        public void Push(T item)
        {
            _innerList.AddFirst(item);
        }

        public T Pop()
        {
            if (_innerList.Head is null)
            {
                throw new Exception("The stack is empty!");
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
