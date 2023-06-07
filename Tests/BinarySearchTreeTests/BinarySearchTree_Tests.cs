using BinarySearchTree;

namespace BinarySearchTreeTests
{
    public class BinarySearchTree_Tests
    {
        private BinarySearchTree<int> _binarySearchTree;
        public BinarySearchTree_Tests()
        {   
            _binarySearchTree = new BinarySearchTree<int>(new int[]{45,35,59,24,40,50,68});
        }

        /*         45 
                  /  \
                35    59
               /  \   / \ 
             24   40 50  68
        */

        //Recursive
        [Fact]
        public void PreOrder_TraversalTest() 
        {
            var list = new List<int>();
            _binarySearchTree.PreOrder(_binarySearchTree.Root, list); // 45 35 24 40 59 50 68 

            Assert.Collection(list,
                item => Assert.Equal(45,item),
                item => Assert.Equal(35,item),
                item => Assert.Equal(24,item),
                item => Assert.Equal(40,item),
                item => Assert.Equal(59,item),
                item => Assert.Equal(50,item),
                item => Assert.Equal(68,item));
            Assert.Equal(7,list.Count);
        }

        [Fact]
        public void InOrder_TraversalTest() // 24 35 40 45 50 59 68 
        {
            var list = new List<int>();
            _binarySearchTree.InOrder(_binarySearchTree.Root,list);
            Assert.Equal(7, list.Count);

            Assert.Collection(list,
                item => Assert.Equal(24, item),
                item => Assert.Equal(35, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(59, item),
                item => Assert.Equal(68, item));
        }

        [Fact]
        public void PostOrder_TraversalTest() // 24 40 35 50 68 59 45 
        {
            var list = new List<int>();
            _binarySearchTree.PostOrder(_binarySearchTree.Root, list);
            Assert.Equal(7, list.Count);

            Assert.Collection(list,
                item => Assert.Equal(24, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(35, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(68, item),
                item => Assert.Equal(59, item),
                item => Assert.Equal(45, item));
        }
        
        // Iterative
        [Fact]
        public void PreOrderIterative_TraversalTest()
        {
            var list = new List<int>();
            _binarySearchTree.PreOrderIterative(_binarySearchTree.Root, list); // 45 35 24 40 59 50 60 

            Assert.Collection(list,
                item => Assert.Equal(45, item),
                item => Assert.Equal(35, item),
                item => Assert.Equal(24, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(59, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(68, item));
            Assert.Equal(7, list.Count);
        }

        [Fact]
        public void InOrderIterative_TraversalTest() // 24 35 40 45 50 59 68 
        {
            var list = new List<int>();
            _binarySearchTree.InOrderIterative(_binarySearchTree.Root, list);
            Assert.Equal(7, list.Count);

            Assert.Collection(list,
                item => Assert.Equal(24, item),
                item => Assert.Equal(35, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(59, item),
                item => Assert.Equal(68, item));
        }

        [Fact]
        public void PostOrderIterative_TraversalTest() // 24 40 35 50 68 59 45 
        {
            var list = new List<int>();
            _binarySearchTree.PostOrderIterative(_binarySearchTree.Root, list);
            Assert.Equal(7, list.Count);

            Assert.Collection(list,
                item => Assert.Equal(24, item),
                item => Assert.Equal(40, item),
                item => Assert.Equal(35, item),
                item => Assert.Equal(50, item),
                item => Assert.Equal(68, item),
                item => Assert.Equal(59, item),
                item => Assert.Equal(45, item));
        }
    }
}