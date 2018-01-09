using System;

public class ArrayList<T>
{
    private T[] arr;

    public int Count { get; set; }
    public int Capacity { get; set; }

    public ArrayList(int capacity = 2)
    {
        arr = new T[capacity];
        Capacity = capacity;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return arr[index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            arr[index] = value;
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
        if (index >= Count)
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
}