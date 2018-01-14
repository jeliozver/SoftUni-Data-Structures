using System;

public class StartUp
{
    public static void Main()
    {
        var revList = new ReversedList<int>();

        revList.Add(1);
        revList.Add(2);
        revList.Add(3);
        revList.Add(4);
        revList.Add(5);

        foreach (var num in revList)
        {
            Console.Write($"{num} ");
        }

        Console.WriteLine();

        int indexOne = 0;
        int indexTwo = 4;

        Console.WriteLine(revList[indexOne]);
        Console.WriteLine(revList[indexTwo]);

        revList.RemoveAt(2);

        foreach (var num in revList)
        {
            Console.Write($"{num} ");
        }

        Console.WriteLine();
    }
}