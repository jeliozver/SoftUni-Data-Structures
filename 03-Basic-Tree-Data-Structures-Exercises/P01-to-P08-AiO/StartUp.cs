using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();
        Tree<int> root = GetRootNode();

        // P01-Root-Node (uncomment next line if you want to test in Judge) (100 / 100)
        // Console.WriteLine($"Root node: {root.Value}");

        // P02-Print-Tree (uncomment next line if you want to test in Judge) (100 / 100)
        // root.PrintTree();

        // PO3-Leaf-Nodes (uncomment next two lines if you want to test in Judge) (100 / 100)
        // List<Tree<int>> leafNodes = root.GetLeafNodes();
        // PrintLeafNodes(leafNodes);

        // PO4-Middle-Nodes (uncomment next two lines if you want to test in Judge) (100 / 100)
        // List<Tree<int>> middleNodes = root.GetMiddleNodes();
        // PrintMiddleNodes(middleNodes);

        // P05-Deepest-Node (uncomment next five lines if you want to test in Judge) (100 / 100)
        // List<Tree<int>> nodesDeepness = root
        //    .GetNodesDeepness()
        //    .OrderByDescending(x => x.Deepness)
        //    .ToList();
        // Console.WriteLine($"Deepest node: {nodesDeepness[0].Value}");

        // PO6-Longest-Path (uncomment next seven lines if you want to test in Judge) (100 / 100)
        // List<Tree<int>> nodesDeepness = root
        //   .GetNodesDeepness()
        //   .OrderByDescending(x => x.Deepness)
        //   .ToList();
        // Tree<int> deepestNode = nodesDeepness[0];
        // List<int> longestPath = deepestNode.GetPath();
        // Console.WriteLine($"Longest path: {string.Join(" ", longestPath)}");

        // P07-All-Paths-With-a-Given-Sum (uncomment next three lines if you want to test in Judge) (100 / 100)
        // int sum = int.Parse(Console.ReadLine());
        // List<Tree<int>> leafNodes = root.GetLeafNodes();
        // PrintPathsOfSum(leafNodes, sum);

        // P08-All-Subtrees-With-a-Given-Sum (uncomment next three lines if you want to test in Judge) (80 / 100)
        // int sum = int.Parse(Console.ReadLine());
        // List<Tree<int>> subTrees = root.GetSubTrees();
        // PrintSubTreesOfSum(subTrees, sum);
    }

    public static void ReadTree()
    {
        int nodeCout = int.Parse(Console.ReadLine());

        for (int i = 1; i < nodeCout; i++)
        {
            string[] edge = Console.ReadLine()
                .Split(' ');

            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    public static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetNodeByValue(parent);
        Tree<int> childNode = GetNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    public static Tree<int> GetNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }

    public static Tree<int> GetRootNode()
    {
        return nodeByValue.Values
            .FirstOrDefault(x => x.Parent == null);
    }

    public static void PrintLeafNodes(List<Tree<int>> leafNodes)
    {
        var sb = new StringBuilder();

        foreach (var leaf in leafNodes.OrderBy(x => x.Value))
        {
            sb.Append($"{leaf.Value} ");
        }

        Console.WriteLine($"Leaf nodes: {sb.ToString().TrimEnd()}");
    }

    public static void PrintMiddleNodes(List<Tree<int>> middleNodes)
    {
        var sb = new StringBuilder();

        foreach (var leaf in middleNodes.OrderBy(x => x.Value))
        {
            sb.Append($"{leaf.Value} ");
        }

        Console.WriteLine($"Middle nodes: {sb.ToString().TrimEnd()}");
    }

    public static void PrintPathsOfSum(List<Tree<int>> leafNodes, int sum)
    {
        Console.WriteLine($"Paths of sum {sum}:");

        foreach (var node in leafNodes)
        {
            List<int> nodePath = node.GetPath();

            if (nodePath.Sum() == sum)
            {
                Console.WriteLine(string.Join(" ", nodePath));
            }
        }
    }

    public static void PrintSubTreesOfSum(List<Tree<int>> subTrees, int sum)
    {
        Console.WriteLine($"Subtrees of sum {sum}:");

        foreach (var node in subTrees)
        {
            var sb = new StringBuilder();
            int currentSum = node.Value;
            sb.Append($"{node.Value} ");

            foreach (var child in node.Children)
            {
                sb.Append($"{child.Value} ");
                currentSum += child.Value;
            }

            if (currentSum == sum)
            {
                Console.WriteLine($"{sb.ToString().TrimEnd()}");
            }
        }
    }
}