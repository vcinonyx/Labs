using System;
using System.Linq;
namespace CSharp
{

    public class Program
    {
      
        static void Main() {
            
            CapitalString capitals = new CapitalString("BMW Bape Add".ToCharArray());
            Console.WriteLine(capitals.FindChar());
            Console.WriteLine(capitals.GetLength());
            SymbolString symbols = new SymbolString("paloAlto**_123)u*".ToCharArray());
            Console.WriteLine(symbols.FindChar());            
        }
    }
}
