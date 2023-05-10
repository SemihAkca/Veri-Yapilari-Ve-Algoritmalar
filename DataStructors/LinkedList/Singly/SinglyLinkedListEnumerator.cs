using System.Collections;

namespace LinkedList.Singly;

public class SinglyLinkedListEnumerator<T>:IEnumerator<T>
{
    private SinglyLinkedListNode<T> Head;
    private SinglyLinkedListNode<T> Curr;

    public T Current
    {
        get { return Curr.Value ;}
    }
    object IEnumerator.Current => Current;

    public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
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