using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSharp
{
    class Expression_
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }

        public Expression_() { }
        public Expression_(double A, double B, double C, double D)
        {
            a = A;
            b = B;
            c = C;
            d = D;
        }
        public double Calculate()
        {
            try
            {
               
                if (d > 41) 
                {
                    throw new ArithmeticException("Square root of a negative argument d!");
                }

                if ((Math.Sqrt(41 - d) - b * a + c) == 0)
                {
                    throw new DivideByZeroException("Division by zero.");
                }

                return (a * b / 4 - 1) / (Math.Sqrt(41 - d) - b * a + c);
            }

            catch (Exception ex)
            {
                using (StreamWriter LogExp = new StreamWriter(@"C:\Users\vcinonyx\source\Labs\Lab-6\LogFile.txt", true, System.Text.Encoding.Default))
                {
                    LogExp.WriteLine(ex.Message);
                }
                Console.WriteLine(ex.Message);
            }

            return -1;
        }
    }
}