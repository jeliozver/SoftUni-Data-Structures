using System;
using System.Collections.Generic;

internal interface IBinarySearchTree<T> where T : IComparable
{
    void Insert(T element);

    bool Contains(T element);

    void EachInOrder(Action<T> action);

    BinarySearchTree<T> Search(T element);

    void Delete(T element);

    void DeleteMin();

    void DeleteMax();

    int Count();

    int Rank(T element);

    T Select(int rank);

    T Ceiling(T element);

    T Floor(T element);

    IEnumerable<T> Range(T startRange, T endRange);
}