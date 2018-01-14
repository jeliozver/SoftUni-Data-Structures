using System;

public class StartUp
{
    public static void Main()
    {
        ArrayStack<int> stack = new ArrayStack<int>();

        for (int i = 1; i <= 20; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine(stack.Pop());

        int[] toArray = stack.ToArray();

        Console.WriteLine(string.Join(", ", toArray));
    }
}