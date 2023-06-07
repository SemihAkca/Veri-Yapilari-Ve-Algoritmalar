using DisjointSet;

namespace DisjointSetTests
{
    public class DisjointSet_Tests
    {
        [Fact]
        public void Make_Union_Find_Tests()
        {
            var disjointSet = new DisjointSet<int>(new []{1,2,3,4,5,6,7});
            disjointSet.MakeSet(8);

            Assert.Equal(8, disjointSet.Count);
            Assert.Equal(1, disjointSet.FindSet(1));

            disjointSet.Union(1, 2);
            Assert.Equal(1, disjointSet.FindSet(2));

            disjointSet.Union(2, 3);
            Assert.Equal(1, disjointSet.FindSet(3));

            disjointSet.Union(4, 5);
            Assert.Equal(4, disjointSet.FindSet(4));
            Assert.Equal(4, disjointSet.FindSet(5));


            disjointSet.Union(5, 6);
            Assert.Equal(4, disjointSet.FindSet(5));
            Assert.Equal(4, disjointSet.FindSet(6));


            disjointSet.Union(6, 7);
            Assert.Equal(4, disjointSet.FindSet(7));

            Assert.Equal(4, disjointSet.FindSet(4));
            disjointSet.Union(3, 4);
            Assert.Equal(1, disjointSet.FindSet(4));

        }
    }
}