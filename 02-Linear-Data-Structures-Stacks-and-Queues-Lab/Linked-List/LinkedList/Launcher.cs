using System;

class Launcher
{
    public static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();

        list.AddFirst(1);
        list.AddLast(2);
        list.AddFirst(3);
        list.AddLast(4);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Now removing first and last");

        list.RemoveFirst();
        list.RemoveLast();

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}