using System;

public class StartUp
{
    public static void Main()
    {
        var linkedStack = new LinkedStack<int>();

        for (int i = 1; i <= 20; i++)
        {
            linkedStack.Push(i);
        }

        linkedStack.Pop();

        int[] toArray = linkedStack.ToArray();

        Console.WriteLine(string.Join(", ", toArray));
    }
}