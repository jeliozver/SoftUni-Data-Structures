using System;

namespace P05_Linked_Queue
{
    public class StartUp
    {
        public static void Main()
        {
            var linkedQueue = new LinkedQueue<int>();

            for (int i = 1; i <= 10; i++)
            {
                linkedQueue.Enqueue(i);
            }

            int[] toArray = linkedQueue.ToArray();

            Console.WriteLine(string.Join(", ", toArray));

            Console.WriteLine(linkedQueue.Dequeue());
            linkedQueue.Enqueue(50);
            Console.WriteLine(linkedQueue.Dequeue());

            toArray = linkedQueue.ToArray();

            Console.WriteLine(string.Join(", ", toArray));
        }
    }
}