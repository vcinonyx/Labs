using System;
using System.Linq;

namespace CSharp
{
    class SymbolString:BaseString
    {
        public SymbolString(params char[] str) : base()
        {
            string temp = "";
            foreach (char a in str)
            {
                if (Char.IsPunctuation(a)||Char.IsSymbol(a))
                {
                    temp += a;
                }
            }
            StrValue = temp.ToCharArray();
        }
        public char[] GetValue() => StrValue;
        public override int GetLength() => StrValue.Length;
        public override int FindChar(char c = '*')
        {
            return base.FindChar('*');
        }
    }
}
