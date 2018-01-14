using System;

public class LinkedQueue<T>
{
    private class QueueNode<T>
    {
        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        }
    }

    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        var currentNode = new QueueNode<T>(element);

        if (this.Count == 0)
        {
            this.head = currentNode;
            this.tail = currentNode;
        }
        else
        {
            this.tail.NextNode = currentNode;
            currentNode.PrevNode = this.tail;
            this.tail = currentNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var firstNode = this.head;
        this.head = this.head.NextNode;

        this.Count--;
        return firstNode.Value;
    }

    public T[] ToArray()
    {
        var result = new T[this.Count];
        var nextNode = this.head;

        for (int i = 0; i < this.Count; i++)
        {
            result[i] = nextNode.Value;
            nextNode = nextNode.NextNode;
        }

        return result;
    }
}