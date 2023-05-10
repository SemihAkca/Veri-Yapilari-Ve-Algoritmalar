using Assert = Xunit.Assert;
namespace RecursionTests
{
    public class RecursionTests
    {
        [Fact]
        public void Total_Test()
        {
            var result = new Recursion.Recursion().Total(10);
            Assert.Equal(55,result);
        }

        [Fact]
        public void FactorialTest()
        {
            var result = new Recursion.Recursion().Factorial(5);
            Assert.Equal(120, result);
        }
        [Fact]
        public void Fibonacci_Test()
        {
            var result = new Recursion.Recursion().Fibonacci(7);
            var result2 = new Recursion.Recursion().Fibonacci(10);
            Assert.Equal(13, result);
            Assert.Equal(55, result2);
        }
    }
}