namespace P04_Remove_Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var occurances = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (!occurances.ContainsKey(number))
                {
                    occurances[number] = 0;
                }

                occurances[number]++;
            }

            foreach (var number in numbers)
            {
                if (occurances[number] % 2 == 0)
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }
    }
}