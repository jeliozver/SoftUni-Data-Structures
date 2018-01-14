using System;

public class ArrayStack<T>
{
    private T[] elements;
    public int Count { get; private set; }

    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }

        elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        this.Count--;
        var element = this.elements[this.Count];

        return element;
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];

        for (int i = 0; i < this.Count; i++)
        {
            arr[i] = this.elements[this.Count - i - 1];
        }

        return arr;
    }

    private void Grow()
    {
        T[] newElements = new T[2 * this.elements.Length];

        for (int i = 0; i < this.Count; i++)
        {
            newElements[i] = this.elements[i];
        }

        this.elements = newElements;
    }
}