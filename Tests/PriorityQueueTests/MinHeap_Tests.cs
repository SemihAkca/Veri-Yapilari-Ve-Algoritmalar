using Newtonsoft.Json.Linq;
using PriorityQueue;

namespace PriorityQueueTests
{
    public class MinHeap_Tests
    {
        private MinHeap<int> minHeap { get; set; }
        public MinHeap_Tests()
        {
            minHeap = new MinHeap<int>(new int[] { 1, 2, 3, 4, 5, 6 });
        }

        [Fact]
        public void Count_Test()
        {
            var result = minHeap.Count;
            Assert.Equal(6, result);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            Assert.Collection(minHeap,
                item => Assert.Equal(1,item),
                item => Assert.Equal(2,item),
                item => Assert.Equal(3,item),
                item => Assert.Equal(4,item),
                item => Assert.Equal(5,item),
                item => Assert.Equal(6,item));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void Add_Test(int value)
        {
            var minHeap = new MinHeap<int>(new int[] { 1, 2, 3, 4, 5, 6, value });
            
            Assert.Collection(minHeap,
                item => Assert.Equal(1,item),
                item => Assert.Equal(2,item),
                item => Assert.Equal(3,item),
                item => Assert.Equal(4,item),
                item => Assert.Equal(5,item),
                item => Assert.Equal(6,item),
                item => Assert.Equal(value,item));

            Assert.Equal(value,minHeap.Array.GetItem(minHeap.Count-1));
        }

        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void HeapifyUp_Test(int value)
        {
            /*
                  10
                 /  \
                20   30
               / \   / \
              40 50 60  value


                  10
                 /  \
                20  value
               / \   / \
              40 50 60 30


                value
                 /  \
                20  10
               / \   / \
              40 50 60  30
            
        */
            var minHeap = new MinHeap<int>(new int[] { 10, 20, 30, 40 ,50,60,value});

            Assert.Collection(minHeap,
                item => Assert.Equal(value,item),
                item => Assert.Equal(20,item),
                item => Assert.Equal(10,item),
                item => Assert.Equal(40,item),
                item => Assert.Equal(50,item),
                item => Assert.Equal(60,item),
                item => Assert.Equal(30, item));
        }

        [Fact]
        public void Remove_Test()
        {
            /*    10
                 /  \
                20   30
               / \   / 
              40 50 60 
            */

            /*    60
                 /  \
                20   30
               / \    
              40 50  
            */

            /*    20
                 /  \
                60   30
               / \    
              40 50  
            */

            /*    20
                 /  \
                40   30
               / \    
              60 50  
            */

            var minHeap = new MinHeap<int>(new int[] { 10, 20, 30, 40, 50, 60 });
            var removedItem = minHeap.DeleteMinMax();

            Assert.Collection(minHeap,
                item => Assert.Equal(20, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(30, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(50, item));

            Assert.Equal(10, removedItem);
        }

        [Theory]
        [InlineData(70)]
        [InlineData(80)]
        [InlineData(90)]
        public void Remove_AfterAdd_Test(int value)
        {
         //   10
         //  /  \
         //   20   30
         //  / \   / \
         // 40 50 60[value]


         //   [value]
         //    /  \
         //   20   30
         //  / \   /
         // 40 50 60


         //     20
         //    /  \
         //[value] 30
         //  / \   /
         // 40 50 60


         //     20
         //    /  \
         //   40   30
         //  / \   /
         //[v] 50 60

            var minHeap = new MinHeap<int>(new int[] { 10, 20, 30, 40, 50, 60, value });
            var removedItem = minHeap.DeleteMinMax();

            Assert.Collection(minHeap,
                item => Assert.Equal(20, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(30, item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(60, item)
                );
            Assert.Equal(10, removedItem);
        }

    }
}