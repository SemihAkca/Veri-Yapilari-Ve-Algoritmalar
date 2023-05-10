using Utilities;

namespace SortingAlgoritms;

public static class SelectionSort
{
    public static void Sort<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length-1; i++)
        {
            var minIndex = i;
            var minValue = arr[i];
            for (int j = i+1; j < arr.Length; j++)
            {
                if (minValue.CompareTo(arr[j]) >= 1)
                {
                    minIndex = j;
                    minValue = arr[j];
                }
            }
            Sorting.Swap(arr,i,minIndex);
        }
    }

    public static void Sort<T>(T[] arr, SortDirection sortDirection = SortDirection.Ascending)
        where T : IComparable<T>
    {
        var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
        for (int i = 0; i < arr.Length-1; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                if (comparer.Compare(arr[j], arr[i]) >= 0)
                {
                    continue;
                }
                Sorting.Swap(arr,i,j);
            }
        }
    }
}