using System;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            Indexer obj = new Indexer(5);
            obj.FillMatrix();
            int IntNumb = obj.IntNumb;
            string first =  obj[0];
            string second = obj[4];
        }
    }
}              