using System.Collections;

namespace LinkedList.Doubly;

public class DoublyLinkedListEnumerator<T>:IEnumerator<T>
{
    private DbNode<T> Head { get; set; }
    private DbNode<T> Curr { get; set; }
    
    public T Current => Curr.Value;
    object IEnumerator.Current => Current;

    public DoublyLinkedListEnumerator(DbNode<T> head)
    {
        Head = head;
        Curr = null;
    }

    public bool MoveNext()
    {
        if (Head is null)
        {
            return false;
        }

        if (Curr is null)
        {
            Curr = Head;
            return true;
        }

        if (Curr.Next is not null)
        {
            Curr = Curr.Next;
            return true;
        }
        return false;   
    }

    public void Reset()
    {
        Head = null;
        Curr = null;
    }

    
    public void Dispose()
    {
        Head = null;
    }
}