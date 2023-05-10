using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class Array<T>:IEnumerable<T>
    {
        public T[] InnerArray;
        private int _Index;
        public int Count => _Index;
        public int Capacity => InnerArray.Length;

        public Array(int defaultSize = 4)
        {
            InnerArray = new T[defaultSize];
            _Index = 0;
        }

        public Array(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (_Index < 0 || _Index > InnerArray.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (_Index == InnerArray.Length)
            {
                DoubleArray(InnerArray);
            }
            InnerArray[_Index] = item;
            _Index++;
        }

        private void DoubleArray(T[] array)
        {
            var newArr = new T[array.Length * 2];
            System.Array.Copy(array, newArr, array.Length);
            InnerArray = newArr;
        }

        public T GetItem(int position)
        {
            if (position < 0 || position >= InnerArray.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return InnerArray[position];
        }

        public void SetItem(int position, T item)
        {
            if (position < 0 || position >= InnerArray.Length)
            {
                throw new IndexOutOfRangeException(nameof(position));
            }
            InnerArray[position] = item;
        }

        public void Swap(int p1, int p2)
        {
            var temp = InnerArray[p1];
            InnerArray[p1] = InnerArray[p2];
            InnerArray[p2] = temp;
        }

        public T RemoveAt(int position)
        {
            if (position < 0 || position >= InnerArray.Length)
            {
                throw new IndexOutOfRangeException();
            }
            var item = InnerArray[position];
            SetItem(position, default(T));
            _Index--;
            for (int i = position; i < InnerArray.Length - 1; i++)
            {
                Swap(position, position + 1);
            }

            if (_Index == InnerArray.Length / 2)
            {
                HalfArray(InnerArray);
            }
            return item;
        }

        private void HalfArray(T[] array)
        {
            var newArr = new T[array.Length / 2];
            System.Array.Copy(array, newArr, newArr.Length);
            InnerArray = newArr;
        }

        public int Find(T item)
        {
            for (int i = 0; i < InnerArray.Length; i++)
            {
                if (InnerArray[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public T[] Copy(int p1, int p2)
        {
            var newArray = new T[p2 - p1];
            if (p1 > p2 || p1 == p2 || p1 >= InnerArray.Length || p2 >= InnerArray.Length)
            {
                throw new Exception("indexleri düzgün giriniz!");
            }
            int j = 0;
            for (int i = p1; i < p2; i++)
            {
                newArray[j] = InnerArray[i];
                j++;
            }
            return newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(InnerArray,_Index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] Union(T[] arr1, T[] arr2)
        {
            var newArr = arr1.Union(arr2);
            return newArr.ToArray();
        }
        public T[] Intersect(T[] arr1, T[] arr2)
        {
            var newArr = arr1.Intersect(arr2);
            return newArr.ToArray();
        }
        public T[] Except(T[] arr1, T[] arr2)
        {
            var newArr = arr1.Except(arr2);
            return newArr.ToArray();
        }

        public T[] HashSet(T[] arr)
        {
            var newArr = arr.ToHashSet<T>().ToArray();
            return newArr;
        }

        public T[] Concate(T[] arr)
        {
            foreach (var item in arr) { Add(item); }

            return InnerArray;
        }
    }
}
