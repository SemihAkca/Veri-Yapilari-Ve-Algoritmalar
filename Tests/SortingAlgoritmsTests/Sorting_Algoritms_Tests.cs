namespace SortingAlgoritmsTests
{
    public class Sorting_Algoritms_Tests
    {
        [Fact]
        public void BubbleSort_Test()
        {
            var arr = new int[] {2,12,1,52,34};
            SortingAlgoritms.BubbleSort.Sort<int>(arr);
            Assert.Collection(arr,
                item => Assert.Equal(1,item),
                item => Assert.Equal(2,item),
                item => Assert.Equal(12,item),
                item => Assert.Equal(34,item),
                item => Assert.Equal(52,item));
        }

        [Fact]
        public void SelectionSort_Test()
        {
            var arr = new int[] { 2, 12, 1, 52, 34 };
            SortingAlgoritms.SelectionSort.Sort<int>(arr);
            Assert.Collection(arr,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(12, item),
                item => Assert.Equal(34, item),
                item => Assert.Equal(52, item));

            var arr2 = new int[] { 25, 32, 8, 11, 4 ,56};
            SortingAlgoritms.SelectionSort.Sort(arr2,Utilities.SortDirection.Descending);
            Assert.Collection(arr2,
                item => Assert.Equal(56, item),
                item => Assert.Equal(32,item),
                item => Assert.Equal(25,item),
                item => Assert.Equal(11,item),
                item => Assert.Equal(8,item),
                item => Assert.Equal(4,item));
        }
        [Fact]
        public void QuickSort_Test()
        {
            var arr = new double[] {45.3,23.5,12.4,69.2};
            SortingAlgoritms.QuickSort.Sort<double>(arr);
            Assert.Collection(arr,
                item => Assert.Equal(12.4, item),
                item => Assert.Equal(23.5, item),
                item => Assert.Equal(45.3, item),
                item => Assert.Equal(69.2, item));
        }
    }
}