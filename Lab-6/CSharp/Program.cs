using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression_ [] example = { new Expression_(), new Expression_(3, 2, 0, 45), new Expression_(0, 0, 0, 41) };
            example[0].a = 1;
            example[0].b = 2;
            example[0].c = 3;
            example[0].d = 4;
            example[0].Calculate();
            example[1].Calculate();
            example[2].Calculate();
        }

    }
}
