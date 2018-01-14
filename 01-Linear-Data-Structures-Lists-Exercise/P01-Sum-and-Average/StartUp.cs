namespace P01_Sum_and_Average
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
                List<int> numbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                int sum = numbers.Sum();
                double average = numbers.Average();

                Console.WriteLine($"Sum={sum}; Average={average:f2}");
            }
            catch (Exception)
            {
                Console.WriteLine("Sum=0; Average=0.00");
            }
        }
    }
}