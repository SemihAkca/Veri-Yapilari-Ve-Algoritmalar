using Stack;

namespace StackTests
{
    public class LinkedListStackTests
    {
        [Fact]
        public void Push_Pop_Peek_Test()
        {
            var stack = new LinkedListStackSingly<int>();
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            var removedItem = stack.Pop();
            var result = stack.Peek();

            Assert.Equal(1,removedItem);
            Assert.Equal(2,stack.Count);
            Assert.Equal(2,result);
        }
    }
}