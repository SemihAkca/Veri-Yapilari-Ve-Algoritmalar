using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack.Contrats;

namespace Stack
{
    public class ArrayStack<T>:IStack<T>
    {
        private Array.Array<T> _innerArray;

        public ArrayStack()
        {
            _innerArray = new Array.Array<T>();
        }
        public ArrayStack(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }
        public int Count => _innerArray.Count;
        private int lastIndex => _innerArray.Count - 1;
        public void Push(T item)
        {
            _innerArray.Add(item);
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("The stack is empty!");
            }

            return _innerArray.RemoveAt(lastIndex);
        }

        public T Peek()
        {
            return Count == 0
                ? default(T)
                : _innerArray.GetItem(lastIndex);
        }
    }
}
