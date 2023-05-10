using LinkedList.Singly;

namespace SinglyLinkedListTests
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void Add_Tests()
        {
            var linkedList = new SinglyLinkedList<int>(new int[]{3,2,1});
            linkedList.AddLast(4);
            linkedList.AddBefore(linkedList.Head.Next,9);
            linkedList.AddAfter(linkedList.Head.Next.Next,8);
            Assert.Equal(6, linkedList.Count);
            Assert.Collection<int>(linkedList,
               item => Assert.Equal(item,1),
               item => Assert.Equal(item,9),
               item => Assert.Equal(item,2),
               item => Assert.Equal(item,8),
               item => Assert.Equal(item,3),
               item => Assert.Equal(item,4));
        }

        [Fact]
        public void Remove_Tests()
        {
            var linkedList = new SinglyLinkedList<int>(new int[]{5,4,3,2,1});
            var firstRemovedItem = linkedList.RemoveFirst();
            linkedList.RemoveLast();
            var removedItem = linkedList.Remove(3);
            Assert.Equal(2,linkedList.Count);
            Assert.Equal(2,linkedList.Head.Value);

            Assert.Collection<int>(linkedList,
                item => Assert.Equal(item,2),
                item => Assert.Equal(item,4));
        }
    }
}