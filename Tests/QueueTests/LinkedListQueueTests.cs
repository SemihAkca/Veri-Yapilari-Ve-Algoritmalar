using Queue;

namespace QueueTests
{
    public class LinkedListQueueTests
    {
        [Fact]
        public void Queue_Tests()
        {
            var queue = new LinkedListQueueDoubly<int>(new int[]{1,2,3});
            queue.EnQueue(4);
            var removedItem = queue.DeQueue();
            var result = queue.Peek();

            Assert.Equal(1, removedItem);
            Assert.Equal(2,result);
            Assert.Equal(3,queue.Count);
        }
    }
}