using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Contrats
{
    public interface IQueue<T>
    {
        int Count { get; }
        void EnQueue(T item);
        T DeQueue();
        T Peek();
    }
}
