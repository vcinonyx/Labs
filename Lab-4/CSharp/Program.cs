namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle T1 = new Triangle();
            Triangle T2 = new Triangle(1, 2, 4, 1, 6, 8);
            Triangle T3 = new Triangle(T2);
            T1.GetInfo();
            T2.GetInfo();
            T3.GetInfo();
            T3 *= 2;
            T3.GetInfo();
            T1 = T2 + T3;
            T1.GetInfo();
        }
    }
}
