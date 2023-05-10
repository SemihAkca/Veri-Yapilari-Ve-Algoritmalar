using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue.Contrats;

namespace Queue
{
    public class ArrayQueue<T>:IQueue<T>
    {
        private Array.Array<T> _innerArray;

        public ArrayQueue()
        {
            _innerArray = new Array.Array<T>();
        }

        public ArrayQueue(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                EnQueue(item);
            }
        }
        public int Count => _innerArray.Count;
        public void EnQueue(T item)
        {
            _innerArray.Add(item);
        }

        public T DeQueue()
        {
            if (Count == 0)
            {
                throw new Exception("The array queue is empty!");
            }

            return _innerArray.RemoveAt(0);
        }

        public T Peek()
        {
            return Count == 0
                ? default(T)
                : _innerArray.GetItem(0);
        }
    }
}
