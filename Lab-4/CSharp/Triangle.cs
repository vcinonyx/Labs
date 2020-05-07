using System;

namespace CSharp
{
    class Triangle
    {

        readonly private double X1, Y1, X2, Y2, X3, Y3;

        public Triangle()
        {
            X1 = 0;
            Y1 = 0;
            X2 = 0;
            Y2 = 1;
            X3 = 1;
            Y3 = 0;
        }
        public Triangle(Triangle copyTriangle)
        {
            X1 = copyTriangle.X1;
            X2 = copyTriangle.X2;
            X3 = copyTriangle.X3;
            Y1 = copyTriangle.Y1;
            Y2 = copyTriangle.Y2;
            Y3 = copyTriangle.Y3;
        }
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
            
        }

        private double Side(double X1, double Y1, double X2, double Y2)
        { 
            double side = ((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
            if (side == 0)
            {
                throw new ArgumentException("Wrong Coordinates");
            }
            return Math.Sqrt(side);
        }

       private double Perimeter()
        {
            double P = Side(X1, Y1, X2, Y2) + Side(X1, Y1, X3, Y3) + Side(X3, Y3, X2, Y2);
            return P;
        }

        private double Square()
        {
            double S;
            double p = Perimeter() / 2;
            double a = Side(X1, Y1, X2, Y2);
            double b = Side(X2, Y2, X3, Y3);
            double c = Side(X1, Y1, X3, Y3);
            S = Math.Sqrt(p * (p - a) * (p - b) *(p - c));
            return S;
        }

        public static Triangle operator *(Triangle T, double factor)
        {
            if (factor == 0)
            {
                throw new ArgumentException(" Factor = 0 ! ");
            }
            Triangle result = new Triangle(T.X1* factor, T.Y1 * factor, T.X2 * factor, T.Y2 * factor, T.X3 * factor, T.Y3 * factor);
            return result;
        }
        public static Triangle operator *(double factor, Triangle T)
        {
            if ( factor == 0)
            {
                throw new ArgumentException(" Factor = 0 ! ");
            }
            return T*factor;
        }

        public static Triangle operator +(Triangle T1, Triangle T2)
        {
            Triangle result = new Triangle(T1.X1 + T2.X1, T1.Y1 + T2.Y1, T1.X2+ T2.X2, T1.Y2+ T2.Y2, T1.X3+ T2.X3, T1.Y3 + T2.Y3);
            return result;
        }
    } 
}
;