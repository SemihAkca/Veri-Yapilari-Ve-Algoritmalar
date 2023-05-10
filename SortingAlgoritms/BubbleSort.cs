namespace SortingAlgoritms
{
    public static class BubbleSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length-i-1; j++)
                {
                    if (arr[j].CompareTo(arr[j+1]) >= 0)
                    {
                        Sorting.Swap(arr,j,j+1);
                    }
                }
            }
        }
    }
}