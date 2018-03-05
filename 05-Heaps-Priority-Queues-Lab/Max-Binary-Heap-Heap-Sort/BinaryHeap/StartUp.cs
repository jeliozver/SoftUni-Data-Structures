using System;

public class StartUp
{
    public static void Main()
    {
        Console.WriteLine("Created an empty heap.");
        BinaryHeap<int> heap = new BinaryHeap<int>();
        heap.Insert(5);
        heap.Insert(8);
        heap.Insert(1);
        heap.Insert(3);
        heap.Insert(12);
        heap.Insert(-4);

        Console.WriteLine("Heap elements (max to min):");
        while (heap.Count > 0)
        {
            int max = heap.Pull();
            Console.WriteLine(max);
        }

        int[] arr = { 5, 2, 0, -4, 3, 12 };
        Console.WriteLine($"Unsorted: {string.Join(" ", arr)}");

        Heap<int>.Sort(arr);
        Console.WriteLine($"Sorted: {string.Join(" ", arr)}");
    }
}