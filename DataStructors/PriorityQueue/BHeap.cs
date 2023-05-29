using System.Collections;

namespace PriorityQueue
{
    public abstract class BHeap<T> : IEnumerable<T>
        where T : IComparable
    {
        public Array.Array<T> Array { get; private set; }
        protected int position;
        public int Count { get; private set; }

        public BHeap(int _size = 128)
        {
            Count = 0;
            Array = new Array.Array<T>(_size);
            position = 0;
        }

        public BHeap(IEnumerable<T> collection):this(collection.ToArray().Length)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        protected int GetLeftChildIndex(int i) => 2 * i + 1;
        protected int GetRightChildIndex(int i) => 2 * i + 2;
        protected int GetParentIndex(int i) => (i - 1) / 2;

        public bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        public bool HasRightChild(int i) => GetRightChildIndex(i) < position;

        public bool IsRoot(int i) => i == 0;

        protected T GetLeftChild(int i) => Array.GetItem(GetLeftChildIndex(i));
        protected T GetRightChild(int i) => Array.GetItem(GetRightChildIndex(i));
        protected T GetParent(int i) => Array.GetItem(GetParentIndex(i));

        public bool IsEmpty() => position == 0;

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Empty heap");
            return Array.GetItem(0);
        }

        public void Swap(int first, int second)
        {
            var temp = Array.GetItem(first);
            Array.SetItem(first,Array.GetItem(second));
            Array.SetItem(second,temp);
        }

        public void Add(T item)
        {
            Array.SetItem(position,item);
            position++;
            Count++;
            HeapifyUp();

        }

        public T DeleteMinMax()
        {
            if (position == 0)
            {
                throw new IndexOutOfRangeException("Underflow");
            }

            var temp = Array.GetItem(0);
            Array.SetItem(0,Array.GetItem(position-1));
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        protected abstract void HeapifyUp();
        protected abstract void HeapifyDown();


        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}