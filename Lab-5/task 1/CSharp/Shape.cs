using System;

namespace CSharp
{
    class Shape
    {
        protected Point[] Points;
        protected double[] Sides;
        public Shape(params Point[] coords)
        {
            if (coords.Length  > 2)
            {
                Points = coords;
            }
            else
            {
                throw new ArgumentException("Coordinates amount should be > 2");
            }
            
            int length = coords.Length;
            int N = length + (length*(length - 3))/ 2; // add diagonals number
            Sides = new double[N];
            int Count = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = (i + 1); j < length; j++)
                {
                    Sides[Count++] = GetLength(Points[j], Points[i]);
                }
            }
        }

        protected double GetLength(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
        }

        public double Area()
        {
            return 0;
        }
        public  double Perimeter()
        {
            return 0;
        }
    }

    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; }
        public double Y { get; }
    }
}
