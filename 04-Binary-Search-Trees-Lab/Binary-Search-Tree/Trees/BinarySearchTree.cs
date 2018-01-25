using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    private class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }

    public BinarySearchTree()
    {
        this.root = null;
    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public void Insert(T value)
    {
        this.root = this.InsertRec(this.root, value);
    }

    private Node InsertRec(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        int compare = node.Value.CompareTo(value);

        if (compare > 0)
        {
            node.Left = this.InsertRec(node.Left, value);
        }
        else if (compare < 0)
        {
            node.Right = this.InsertRec(node.Right, value);
        }

        return node;
    }

    public bool Contains(T value)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(value);

            if (compare > 0)
            {
                current = current.Left;
            }
            else if (compare < 0)
            {
                current = current.Right;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        if (this.root.Left == null && this.root.Right == null)
        {
            this.root = null;
            return;
        }

        Node partent = null;
        Node current = this.root;

        while (current.Left != null)
        {
            partent = current;
            current = current.Left;
        }

        if (current.Right != null)
        {
            partent.Left = current.Right;
        }
        else
        {
            partent.Left = null;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(item);

            if (compare > 0)
            {
                current = current.Left;
            }
            else if (compare < 0)
            {
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }

        return null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        List<T> result = new List<T>();

        this.RangeRec(this.root, result, startRange, endRange);

        return result;
    }

    private void RangeRec(Node node, List<T> result, T start, T end)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = node.Value.CompareTo(start);
        int compareHigh = node.Value.CompareTo(end);

        if (compareLow > 0)
        {
            this.RangeRec(node.Left, result, start, end);
        }
        if (compareLow >= 0 && compareHigh <= 0)
        {
            result.Add(node.Value);
        }
        if (compareHigh < 0)
        {
            this.RangeRec(node.Right, result, start, end);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrderRec(this.root, action);
    }

    private void EachInOrderRec(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrderRec(node.Left, action);
        action(node.Value);
        this.EachInOrderRec(node.Right, action);
    }
}