namespace Recursion
{
    public class Recursion
    {
        public int Total(int n)
        {
            if (n <= 0)
                return 0;
            return n + Total(n - 1);
        }

        public int Factorial(int n)
        {
            if (n <= 0)
                return 1;
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        public int Fibonacci(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;
            return Fibonacci(n-2) + Fibonacci(n - 1);
        }

        public void LinkedList_Traverse(LinkedListNode<int> node)
        {
            if (node is null)
                return;
            Console.WriteLine(node.Value);
            LinkedList_Traverse(node.Next);
        }
    }
}