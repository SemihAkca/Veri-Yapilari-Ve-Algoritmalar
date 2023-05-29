using System.Collections;

namespace Array;

public class ArrayEnumerator<T> : IEnumerator<T>
{
    private T[] _array;
    private int _index = -1;
    public ArrayEnumerator(T[] array)
    {
        _array = array;
    }

    public bool MoveNext()
    {
        if (_index < _array.Length-1)
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