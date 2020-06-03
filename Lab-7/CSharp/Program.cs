using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            DLinkedList dlist = new DLinkedList();
            dlist.AddFirst(4.5);
            dlist.AddFirst(21.9);
            dlist.AddFirst(322.5);
            dlist.AddFirst(32224);
            dlist.AddFirst(322.3); 
            dlist.AddFirst(214.5);
            dlist.AddFirst(840);
            dlist.AddFirst(11);
            dlist.AddFirst(342.1);
            dlist.Add(4.2);

            Console.WriteLine($"Average: {dlist.Sum() / dlist.Count}");
            Console.WriteLine($"Sum of all numbers: {dlist.Sum()}");
            Console.WriteLine($"Number of elements lesser than average: {dlist.LessThanAvg()}");
            Console.WriteLine($"Max element: {dlist.FindMax()}");
            Console.Write("Before: ");

            foreach (var l in dlist)
            {
                Console.Write(l + "  ");
            }

            Console.WriteLine();
            Console.Write("After deleting elements after the max one: ");
            dlist.DeleteNodesAfterMax();
            
            foreach (var l in dlist)
            {
                    Console.Write(l + "  ");
            }
            Console.WriteLine();

        }
    }
}
