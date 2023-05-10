using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue;

namespace QueueTests
{
    public class ArrayQueueTests
    {
        [Fact]
        public void EnQueue_DeQueue_Test()
        {
            var queue = new ArrayQueue<int>(new int[]{1,2,3,4});
            queue.EnQueue(5);
            var removedItem = queue.DeQueue();
            var result = queue.Peek();
            
            Assert.Equal(4, queue.Count);
            Assert.Equal(1,removedItem);
            Assert.Equal(2,result);
        }
    }
}
