using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        ConstructHeap(arr);

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Swap(arr, 0, i);
            Down(arr, 0, i);
        }
    }

    private static void ConstructHeap(T[] arr)
    {
        for (int i = arr.Length / 2; i >= 0; i--)
        {
            Down(arr, i, arr.Length);
        }
    }

    private static void Down(T[] arr, int index, int lenght)
    {
        int parentIndex = index;

        while (parentIndex < lenght / 2)
        {
            int childIndex = parentIndex * 2 + 1;

            if (childIndex + 1 < lenght
                && IsGreater(arr, childIndex, childIndex + 1))
            {
                childIndex++;
            }

            int compare = arr[parentIndex]
                .CompareTo(arr[childIndex]);

            if (compare < 0)
            {
                Swap(arr, childIndex, parentIndex);
            }

            parentIndex = childIndex;
        }
    }

    private static bool IsGreater(T[] arr, int left, int right)
    {
        return arr[left]
                   .CompareTo(arr[right]) < 0;
    }

    private static void Swap(T[] arr, int parent, int index)
    {
        T temp = arr[parent];
        arr[parent] = arr[index];
        arr[index] = temp;
    }
}