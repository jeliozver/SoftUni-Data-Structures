namespace P02_Sort_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
       
            words.Sort();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}