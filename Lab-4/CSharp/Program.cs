namespace CSharp
{
    class Program
    {
        static void Main()
        {
            Triangle T1 = new Triangle();
            Triangle T2 = new Triangle(1, 4, 4, 1, 6, 8);
            Triangle T3 = new Triangle(T2);
            T3 = T3 * 2;
            T3 = 2 * T3;
            T1 = T2 + T3;
        }
    }
}
