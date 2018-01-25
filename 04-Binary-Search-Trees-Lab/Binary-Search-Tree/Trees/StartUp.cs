using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var mainTree = new BinarySearchTree<int>();

        mainTree.Insert(5);
        mainTree.Insert(4);
        mainTree.Insert(3);
        mainTree.Insert(7);
        mainTree.Insert(6);

        var searchTree = mainTree.Search(7);
        searchTree.Insert(9);

        Console.WriteLine($"Main tree Contains 9? - {mainTree.Contains(9)}");
        Console.WriteLine($"Search tree Contains 9? - {searchTree.Contains(9)}");

        Console.WriteLine("Delete Min = 3");
        mainTree.DeleteMin();
        Console.WriteLine($"Search tree Contains 3? - {searchTree.Contains(3)}");

        IEnumerable<int> rangeTest = mainTree.Range(4, 6);
        Console.WriteLine($"Main tree Range 4-6: {string.Join(" ", rangeTest)}");

        List<int> list = new List<int>();
        mainTree.EachInOrder(list.Add);
        Console.WriteLine($"Main tree In-Order: {string.Join(" ", list)}");
    }
}