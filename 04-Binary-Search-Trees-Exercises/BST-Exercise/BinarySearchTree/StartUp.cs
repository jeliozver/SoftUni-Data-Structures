using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);

        //List<int> inOrder = new List<int>();
        //bst.EachInOrder(inOrder.Add);
        //int nodeCount = bst.Count();
        //Console.WriteLine($"In Order Initial: {string.Join(", ", inOrder)}"); // 1-3-4-5-8-9-10-37-39-45 (Before)
        //Console.WriteLine($"Count Initial: {nodeCount}"); // Expected 10

        //int rank = bst.Rank(8);
        //Console.WriteLine($"Count of elements smaller than 8: {rank}"); // Expected 4

        //int select = bst.Select(4);
        //Console.WriteLine($"First element with 4 elements smaller than itself: {select}"); // Expected 8

        //int ceiling = bst.Ceiling(4);
        //Console.WriteLine($"Nearest larger value: {ceiling}"); // Expected 5

        //int floor = bst.Floor(9);
        //Console.WriteLine($"Nearest smaller value: {floor}"); // Expected 8

        //bst.DeleteMax();
        //List<int> inOrderAfterDel = new List<int>();
        //bst.EachInOrder(inOrderAfterDel.Add);
        //int nodeCount = bst.Count();
        //Console.WriteLine($"In Order After Del: {string.Join(", ", inOrderAfterDel)}"); // 1-3-4-5-8-9-10-37-39 (Expected after)
        //Console.WriteLine($"Count After Del: {nodeCount}");  // Expected 9

        //bst.DeleteMin();
        //List<int> inOrderAfterDel = new List<int>();
        //bst.EachInOrder(inOrderAfterDel.Add);
        //int nodeCount = bst.Count();
        //Console.WriteLine($"In Order After Del: {string.Join(", ", inOrderAfterDel)}"); // 3-4-5-8-9-10-37-39-45 (Expected after)
        //Console.WriteLine($"Count After Del: {nodeCount}");  // Expected 9

        //bst.Delete(8);
        //List<int> inOrderAfterDel = new List<int>();
        //bst.EachInOrder(inOrderAfterDel.Add);
        //int nodeCount = bst.Count();
        //Console.WriteLine($"In Order After Del: {string.Join(", ", inOrderAfterDel)}"); // 1-3-4-5-9-10-37-39-45 (Expected after)
        //Console.WriteLine($"Count After Del: {nodeCount}");  // Expected 9
    }
}