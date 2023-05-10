using System.Collections;

namespace Array;

public class ArrayEnumerator<T> : IEnumerator<T>
{
    private T[] _array;
    private int _index = -1;
    private int _position;
    public ArrayEnumerator(T[] array,int position)
    {
        _array = array;
        _position = position;
    }

    public bool MoveNext()
    {
        if (_index < _position-1)
        {
            _index++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _index = -1;
    }

    public T Current  => _array[_index];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        _array = null;
    }
}