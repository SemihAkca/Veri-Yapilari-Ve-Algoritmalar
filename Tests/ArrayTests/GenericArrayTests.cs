namespace ArrayTests
{
    public class GenericArrayTests
    {
        [Fact]
        public void GenericArray_Foreach_Copy_Test()
        {
            var array = new Array.Array<int>(new int[]{1,2,3,4});
            array.Add(5);
            Assert.Equal(5,array.Count);
            Assert.Collection<int>(array,
                item => Assert.Equal(item,1),
                item => Assert.Equal(item,2),
                item => Assert.Equal(item,3),
                item => Assert.Equal(item,4),
                item => Assert.Equal(item,5));

            var arr = array.Copy(1, 3);
            Assert.Collection<int>(arr,
                item => Assert.Equal(item, 2),
                item => Assert.Equal(item, 3));

        }

        [Fact]
        public void Remove_Test()
        {
            var arr = new Array.Array<int>(new int[]{1,2,45,3});
            var removedItem = arr.RemoveAt(2);
            Assert.Equal(45, removedItem);
            Assert.Collection<int>(arr,
                item => Assert.Equal(item,1),
                item => Assert.Equal(item,2),
                item => Assert.Equal(item,3));
        }

        [Fact]
        public void Union_Test()
        {
            var arr = new Array.Array<int>();
            var result = arr.Union(new int[] {1,2,12,4,2},new int[]{5,8,4,1});
            Assert.Collection<int>(result,
                item => Assert.Equal(item, 1),
                item => Assert.Equal(item, 2),
                item => Assert.Equal(item, 12),
                item => Assert.Equal(item, 4),
                item => Assert.Equal(item, 5),
                item => Assert.Equal(item, 8));
        }

        [Fact]
        public void Intersect_Test()
        {
            var arr = new Array.Array<int>();
            var result = arr.Intersect(new int[] { 1, 2, 12, 8,2,4 }, new int[] { 5, 9, 4, 3,1,8 });
            Assert.Collection<int>(result,
                item => Assert.Equal(item, 1),
                item => Assert.Equal(item, 8),
                item => Assert.Equal(item, 4));
        }

        [Fact]
        public void Except_Test()
        {
            var arr = new Array.Array<int>();
            var result = arr.Except(new int[] { 1, 12, 2, 4, 2, 8 }, new int[] { 5, 9, 4, 3, 1, 8 });
            Assert.Collection<int>(result,
                item => Assert.Equal(item, 12),
                item => Assert.Equal(item, 2));
        }

        [Fact]
        public void HashSet_Test()
        {
            var arr = new Array.Array<int>().HashSet(new int[] { 1, 21, 5, 1, 3, 2, 21 });
            Assert.Collection<int>(arr,
                item => Assert.Equal(item,1),
                item => Assert.Equal(item,21),
                item => Assert.Equal(item,5),
                item => Assert.Equal(item,3),
                item => Assert.Equal(item,2));
        }

        [Fact]
        public void Concate_Test()
        {
            var numbers = new Array.Array<int>(new int[]{1,2,3});
            numbers.Concate(new int[] { 4, 5, 6 ,7,54});
            Assert.Equal(8,numbers.Count);
            Assert.Collection<int>(numbers,
                item => Assert.Equal(item,1),
                item => Assert.Equal(item,2),
                item => Assert.Equal(item,3),
                item => Assert.Equal(item,4),
                item => Assert.Equal(item,5),
                item => Assert.Equal(item, 6),
                item => Assert.Equal(item, 7),
                item => Assert.Equal(item,54));
        }
    }
}