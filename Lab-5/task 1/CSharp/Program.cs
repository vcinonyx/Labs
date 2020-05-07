using System;

namespace CSharp
{
    class Program
    {
        static void Main()
        {
            Point[] ABCD  = new Point[4]
            {
                new Point(1, 0),
                new Point(0, 0),
                new Point(1, 1),
                new Point(0, 1)
            };

            Square abcd = new Square(ABCD);
            double perimeter = abcd.Perimeter();
            double area = abcd.Area();
        }
    }
}
