namespace Hierarchy.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node root;
        private Dictionary<T, Node> nodesByValue;

        public Hierarchy(T root)
        {
            this.root = new Node(root);
            this.nodesByValue = new Dictionary<T, Node>
            {
                { root, this.root }
            };
        }

        public int Count => this.nodesByValue.Count;

        public void Add(T parent, T child)
        {
            if (!this.nodesByValue.ContainsKey(parent))
            {
                throw new ArgumentException();
            }

            if (this.nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node parentNode = this.nodesByValue[parent];
            Node childNode = new Node(child, parentNode);

            parentNode.Children.Add(childNode);
            this.nodesByValue.Add(child, childNode);
        }

        public void Remove(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            Node current = this.nodesByValue[element];

            if (current.Parent == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var currentChild in current.Children)
            {
                currentChild.Parent = current.Parent;
                current.Parent.Children.Add(currentChild);
            }

            current.Parent.Children.Remove(current);
            nodesByValue.Remove(element);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.nodesByValue.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            Node parent = this.nodesByValue[item];
            return parent.Children.Select(x => x.Value);
        }

        public T GetParent(T item)
        {
            if (!this.nodesByValue.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            Node child = this.nodesByValue[item];

            return child.Parent == null ? default(T) : child.Parent.Value;
        }

        public bool Contains(T value)
        {
            return this.nodesByValue.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            List<T> collection = new List<T>();

            foreach (var node in this.nodesByValue)
            {
                if (other.Contains(node.Key))
                {
                    collection.Add(node.Key);
                }
            }

            return collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();

            Node current = this.root;
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                yield return current.Value;
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node
        {
            public Node Parent { get; set; }
            public T Value { get; private set; }

            public List<Node> Children { get; private set; }

            public Node(T value, Node parent = null)
            {
                this.Value = value;
                this.Children = new List<Node>();
                this.Parent = parent;
            }
        }
    }
}