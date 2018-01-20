using System;
using System.Linq;

public class PlayWithTrees
{
    private static void Main()
    {
        var tree =
            new Tree<int>(7,
                new Tree<int>(19,
                    new Tree<int>(1),
                    new Tree<int>(12),
                    new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                    new Tree<int>(23),
                    new Tree<int>(6)));

        Console.WriteLine("Tree (indented):");
        Console.WriteLine();
        tree.Print();

        Console.WriteLine();

        Console.Write("Tree nodes:");
        tree.Each(c => Console.Write(" " + c));
        Console.WriteLine();

        Console.Write("Order DFS: ");
        var orderDFS = tree.OrderDFS().ToList();
        Console.Write(string.Join(" ", orderDFS));
        Console.WriteLine();

        Console.Write("Order BFS: ");
        var orderBFS = tree.OrderBFS().ToList();
        Console.Write(string.Join(" ", orderBFS));

        Console.WriteLine();
        Console.WriteLine();

        var binaryTree =
            new BinaryTree<string>("*",
                new BinaryTree<string>("+",
                    new BinaryTree<string>("3"),
                    new BinaryTree<string>("2")),
                new BinaryTree<string>("-",
                    new BinaryTree<string>("9"),
                    new BinaryTree<string>("6")));

        Console.WriteLine("Binary tree (indented, pre-order):");
        Console.WriteLine();
        binaryTree.PrintIndentedPreOrder();

        Console.WriteLine();

        Console.Write("Binary tree nodes (pre-order):");
        binaryTree.EachPreOrder(c => Console.Write(" " + c));
        Console.WriteLine();

        Console.Write("Binary tree nodes (in-order):");
        binaryTree.EachInOrder(c => Console.Write(" " + c));
        Console.WriteLine();

        Console.Write("Binary tree nodes (post-order):");
        binaryTree.EachPostOrder(c => Console.Write(" " + c));
        Console.WriteLine();
    }
}