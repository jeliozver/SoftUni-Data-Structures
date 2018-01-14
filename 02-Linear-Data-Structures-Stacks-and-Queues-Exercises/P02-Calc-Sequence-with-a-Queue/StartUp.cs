namespace P02_Calc_Sequence_with_a_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int s = n;
            int skip = 0;

            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            for (int i = 0; i < 49; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        s = sequence.ToArray().Skip(skip).Take(1).ToArray()[0];
                        sequence.Enqueue(s + 1);
                        skip++;
                        break;
                    case 1:
                        sequence.Enqueue(2 * s + 1);
                        break;
                    case 2:
                        sequence.Enqueue(s + 2);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}