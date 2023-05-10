using System.Collections;

namespace Array
{
    public class Array:IEnumerable
    {
        public Object[] InnerArray;
        private int _index;
        public int Count => _index;
        public int Capacity => InnerArray.Length;

        public Array(int defaultSize = 4)
        {
            InnerArray = new Object[defaultSize];
            _index = 0;
        }

        public Array(IEnumerable collection):this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(object item)
        {
            if (_index < 0 || _index > InnerArray.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (_index == InnerArray.Length)
            {
                DoubleArray(InnerArray);
            }
            InnerArray[_index] = item;
            _index++;
        }

        private void DoubleArray(object[] array)
        {
            var newArr = new object[array.Length*2];
            System.Array.Copy(array,newArr,array.Length);
            InnerArray = newArr;
        }

        public object GetItem(int position)
        {
            if (position<0 || position >= InnerArray.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return InnerArray[position];
        }

        public void SetItem(int position, object item)
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

        public object RemoveAt(int position)
        {
            if (position<0 || position >= InnerArray.Length)
            {
                throw new IndexOutOfRangeException();
            }
            var item = InnerArray[position];
            SetItem(position,null);
            _index--;
            for (int i = position; i < InnerArray.Length-1; i++)
            {
                Swap(position,position+1);
            }

            if (_index == InnerArray.Length/2)
            {
                HalfArray(InnerArray);
            }
            return item;
        }

        private void HalfArray(object[] array)
        {
            var newArr = new object[array.Length/2];
            System.Array.Copy(array,newArr,newArr.Length);
            InnerArray = newArr;
        }

        public int Find(object item)
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

        public object[] Copy(int p1, int p2)
        {
            var newArray = new object[p2-p1];
            if (p1>p2 || p1 == p2 || p1>= InnerArray.Length || p2>= InnerArray.Length)
            {
                throw new Exception("indexleri düzgün giriniz!");
            }
            int j = 0;
            for (int i = p1; i < p2; i++)
            {
                InnerArray[p1] = newArray[j];
                j++;
            }
            return newArray;
        }

        public IEnumerator GetEnumerator()
        {
            return InnerArray.GetEnumerator();
        }
    }
}
