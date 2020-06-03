using MyLib;
using System;

namespace Lab_8
{
    class Program
    {
       static void Main()
       {
            Account MyAccount = new Account();
            Tariff[] PossibleTarrifs = MyAccount.GetTariffs();
            MyAccount.Notify += DisplayMessage;
            MyAccount.ChooseTariff(3);
            MyAccount.Put(120);
            MyAccount.UseInternet(12);
            double[] Arr1 = new double[] { 1, 2, 3, 5 };
            double[] Arr2 = new double[] { 1, 2, 3, 4 };
            ArrCompare arrCompare = new ArrCompare();
            Console.WriteLine(ArrCompare.CompareStatic(Arr1, Arr2, 3));
            ArrCompare.EqualityHandler equalityDelegate = new ArrCompare.EqualityHandler(arrCompare.CompareExemplary);
            equalityDelegate?.Invoke(Arr1, Arr2, 3);
            Console.WriteLine(equalityDelegate(Arr1, Arr2, 3));
        }

        private static void DisplayMessage(string message)  
        {
            Console.WriteLine(message); 
        }

        private static void RedColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
