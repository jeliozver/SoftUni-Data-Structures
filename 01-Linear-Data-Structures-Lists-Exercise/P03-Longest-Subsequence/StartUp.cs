namespace P03_Longest_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int currentStart = 0;
            int currentLenght = 1;
            int bestStart = 0;
            int bestLenght = 1;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[currentStart])
                {
                    currentLenght++;
                }
                else
                {
                    currentStart = i;
                    currentLenght = 1;
                }

                if (currentLenght > bestLenght)
                {
                    bestStart = currentStart;
                    bestLenght = currentLenght;
                }
            }

            for (int i = bestStart; i < bestStart + bestLenght; i++)
            {
                Console.Write($"{numbers[i]} ");
            }

            Console.WriteLine();
        }
    }
}