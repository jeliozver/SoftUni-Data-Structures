namespace P06_Sequence_N_M
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public class Item
        {
            public int Value { get; private set; }
            public Item PrevItem { get; private set; }

            public Item(int value, Item prevItem)
            {
                this.Value = value;
                this.PrevItem = prevItem;
            }
        }

        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int m = input[1];

            if (n >= m)
            {
                return;
            }

            var queue = new Queue<Item>(new[] { new Item(n, null) });

            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();

                if (currentItem.Value < m)
                {
                    queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
                    queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
                    queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
                }
                else if (currentItem.Value == m)
                {
                    var result = new List<int>();

                    while (currentItem.PrevItem != null)
                    {
                        result.Insert(0, currentItem.Value);

                        currentItem = currentItem.PrevItem;
                    }

                    result.Insert(0, n);

                    Console.WriteLine(string.Join(" -> ", result));

                    return;
                }
            }
        }
    }
}