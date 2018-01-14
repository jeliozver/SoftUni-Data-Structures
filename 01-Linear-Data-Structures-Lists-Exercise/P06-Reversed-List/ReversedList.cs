using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private T[] arr;

    public int Count { get; private set; }
    public int Capacity { get; private set; }

    public ReversedList(int capacity = 2)
    {
        this.arr = new T[capacity];
        this.Capacity = capacity;
        this.Count = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.arr[Count - index - 1];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.arr[Count - index - 1] = value;
        }
    }

    public void Add(T item)
    {
        if (Count == Capacity)
        {
            Resize();
        }

        arr[Count++] = item;
    }

    public T RemoveAt(int index)
    {
        index = Count - index - 1;

        if (index >= Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        T item = arr[index];
        arr[index] = default(T);
        Shift(index);
        Count--;

        if (Count <= Capacity / 4)
        {
            Shrink();
        }

        return item;
    }

    private void Resize()
    {
        T[] copy = new T[Capacity * 2];
        Capacity *= 2;

        Array.Copy(arr, copy, Count);

        arr = copy;
    }

    private void Shrink()
    {
        T[] copy = new T[Capacity / 2];
        Capacity /= 2;

        Array.Copy(arr, copy, Count);

        arr = copy;
    }

    private void Shift(int index)
    {
        for (int i = index; i < Count; i++)
        {
            arr[i] = arr[i + 1];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}