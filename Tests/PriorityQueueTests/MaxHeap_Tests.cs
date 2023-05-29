using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PriorityQueue;

namespace PriorityQueueTests
{
    public class MaxHeap_Tests
    {
        private MaxHeap<int> maxHeap { get; set; }

        public MaxHeap_Tests()
        {
            maxHeap = new MaxHeap<int>(new int[] { 60, 45, 50, 10, 30, 15, 12, 5});
        }

        [Fact]
        public void Count_Test()
        {
            var result = maxHeap.Count();
            Assert.Equal(8, result);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            Assert.Collection(maxHeap,
                item => Assert.Equal(60,item),
                item => Assert.Equal(45,item),
                item => Assert.Equal(50,item),
                item => Assert.Equal(10,item),
                item => Assert.Equal(30,item),
                item => Assert.Equal(15,item),
                item => Assert.Equal(12, item),
                item => Assert.Equal(5,item));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        public void Add_Test(int value)
        {
            /*
                    60
                   /   \
                 45     50
                / \     /  \
               10  30  15   12
              /  \
             5  value  
            */

            var maxHeap = new MaxHeap<int>(new int[]{ 60, 45, 50, 10, 30 , 15, 12 , 5 ,value});

            Assert.Collection(maxHeap,
                item => Assert.Equal(60, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(10, item),
                item => Assert.Equal(30, item),
                item => Assert.Equal(15, item),
                item => Assert.Equal(12, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(value, item));

            Assert.Equal(value,maxHeap.Array.GetItem(maxHeap.Count-1));
        }

        [Theory]
        [InlineData(70)]
        [InlineData(72)]
        [InlineData(85)]
        public void HeapifyUp_Test(int value)
        {
            /*
                  60
                 /   \
               45     50
              / \     /  \
             10  30  15   12
            /  \
           5  value  
          */
            /*
                  60
                 /   \
               45     50
              / \     /  \
          value  30  15   12
            /  \
           5   10  
          */

            /*
                  60
                 /   \
             value     50
              / \     /  \
             45  30  15   12
            /  \
           10   5  
          */

            /*
                 value
                 /   \
               60     50
              / \     /  \
             45  30  15   12
            /  \
           5    10  
          */
            var maxHeap = new MaxHeap<int>(new int[] { 60, 45, 50, 10, 30, 15, 12, 5, value });

            Assert.Collection(maxHeap,
                item => Assert.Equal(value, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(30, item),
                item => Assert.Equal(15, item),
                item => Assert.Equal(12, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(10, item));
        }

        [Fact]
        public void Remove_Test()
        {
            /*
                  60
                 /   \
               45     50
              / \     /  \
             10  30  15   12
            /  
           5    
          */
            /*
                     5
                   /   \
                 45     50
                / \     /  \
               10  30  15   12

            */

            /*
                     50
                   /   \
                 45      5
                / \     /  \
               10  30  15   12

            */

            /*
                    50
                   /   \
                 45      15
                / \     /  \
               10  30  5   12

            */

            var maxHeap = new MaxHeap<int>(new int[] { 60, 45, 50, 10, 30, 15, 12, 5});
            var removedItem = maxHeap.DeleteMinMax();

            Assert.Collection(maxHeap,
                item => Assert.Equal(50, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(15, item),
                item => Assert.Equal(10, item),
                item => Assert.Equal(30, item),
                item => Assert.Equal(5, item),
                item => Assert.Equal(12, item));
            Assert.Equal(60, removedItem);
        }
    }
}
