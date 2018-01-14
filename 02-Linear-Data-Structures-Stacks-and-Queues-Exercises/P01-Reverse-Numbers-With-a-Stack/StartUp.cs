namespace P01_Reverse_Numbers_With_a_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                Stack<int> stack = new Stack<int>();

                foreach (var number in numbers)
                {
                    stack.Push(number);
                }

                while (stack.Count > 0)
                {
                    int value = stack.Pop();
                    Console.Write($"{value} ");
                }

                Console.WriteLine();
            }
            catch (Exception)
            {
               
            }
        }
    }
}