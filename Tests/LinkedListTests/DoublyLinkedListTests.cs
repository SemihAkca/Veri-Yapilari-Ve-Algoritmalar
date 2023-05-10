using LinkedList.Doubly;

namespace DoublyLinkedListTets
{
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList<int> _linkedList;

        public DoublyLinkedListTests()
        {
            _linkedList = new DoublyLinkedList<int>(new int[]{5,4,2,1});
        }
        [Fact]
        public void Add_Tests()
        {
            _linkedList.AddLast(6);
            _linkedList.AddBefore(_linkedList.Head.Next, 26);
            _linkedList.AddAfter(_linkedList.Head.Next, 3);
            Assert.Equal(7,_linkedList.Count);
            Assert.Equal(6,_linkedList.Tail.Value);

            Assert.Collection<int>(_linkedList,
                item => Assert.Equal(item, 1),
                item => Assert.Equal(item, 26),
                item => Assert.Equal(item, 3),
                item => Assert.Equal(item,2),
                item => Assert.Equal(item,4),
                item => Assert.Equal(item, 5),
                item => Assert.Equal(item,6));
        }

        [Fact]
        public void Remove_Tests()
        {
            _linkedList.AddAfter(_linkedList.Head.Next,3);
            _linkedList.RemoveFirst();
            var removedItem = _linkedList.Remove(3);
            _linkedList.RemoveLast();

            Assert.Equal(3, removedItem);
            Assert.Equal(4,_linkedList.Tail.Value);
            Assert.Equal(2,_linkedList.Count);
            Assert.Equal(2,_linkedList.Head.Value);
            Assert.Collection<int>(_linkedList,
                item => Assert.Equal(item,2),
                item => Assert.Equal(item,4));
        }

        [Fact]
        public void LinkedList_ThrowTest()
        {
            Assert.Throws<Exception>(() => _linkedList.Remove(65));
        }
    }
}