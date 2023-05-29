using BinarySearchTree;

var binarySearchTree = new BinarySearchTree<int>();
var list = new List<int>() { 30, 23, 38, 10, 29, 35, 45 };      //           30 
                                                                //       23       38              
foreach (var item in list)                                 //     10   29   35  45
{
    binarySearchTree.Add(item);
}

//Console.WriteLine(binarySearchTree.Root.Left.Value);
//Console.WriteLine(binarySearchTree.Root.Value);
//Console.WriteLine(binarySearchTree.Root.Right.Value);

//Console.WriteLine();
//Console.WriteLine(binarySearchTree.Root.Left.Left.Value);
//Console.WriteLine(binarySearchTree.Root.Left.Value);
//Console.WriteLine(binarySearchTree.Root.Value);
//Console.WriteLine(binarySearchTree.Root.Right.Value);
//Console.WriteLine(binarySearchTree.Root.Right.Left.Value + "\n");

var newList = new List<int>();
binarySearchTree.InOrder(binarySearchTree.Root,newList); // 10 23 29 30 35 38 45

foreach (var item in newList)
{
    Console.Write($"{item} ");
}