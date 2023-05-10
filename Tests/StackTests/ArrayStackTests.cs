using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;

namespace StackTests
{
    public class ArrayStackTests
    {
        [Fact]
        public void Push_Pop_Peek_Tests()
        {
            var stack = new ArrayStack<int>(new int[]{1,2,3,4});
            var removedItem = stack.Pop();
            var result = stack.Peek();

            Assert.Equal(3,stack.Count);
            Assert.Equal(4,removedItem);
            Assert.Equal(3,result);
        }
    }
}
