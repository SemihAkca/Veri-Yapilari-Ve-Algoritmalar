using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack.Contrats;

namespace Stack
{
    public class Stack<T>:IStack<T>
    {
        private readonly IStack<T> _stack;

        public Stack()
        {
            _stack = new LinkedListStackSingly<T>();
        }

        public Stack(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }
        public int Count => _stack.Count;
        public void Push(T item)
        {
            _stack.Push(item);
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public T Peek()
        {
            return _stack.Peek();
        }
    }
}
