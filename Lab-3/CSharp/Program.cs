using System;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            Indexer obj = new Indexer();
            Indexer obj1 = new Indexer(2);
            obj.FillMatrix();
            Console.WriteLine(obj.IntNumb);
            Console.WriteLine(obj[0]);
            Console.WriteLine(obj[4]);
        }
    }
}
