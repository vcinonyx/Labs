using System;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            Indexer obj = new Indexer();
            obj.FillMatrix();
            obj.PrintMatrix();
            Console.WriteLine(obj.IntNumb);
            Console.WriteLine(obj[0]);
            Console.WriteLine(obj[4]);
        }
    }
}
