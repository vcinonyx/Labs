using System;
using System.Linq;

namespace CSharp
{
    class CapitalString : BaseString
    {
        public CapitalString(params char[] str) : base()
        {
            string temp = "";
            foreach (char a in str)
            {
                if (Char.IsUpper(a)) 
                {
                    temp += a;
                }
            }
            StrValue = temp.ToCharArray();
        }

        public override int FindChar(char c = 'B')
        {
            return base.FindChar('B');
        }

        public char[] GetValue() => StrValue;

        public override int GetLength() => StrValue.Length;

    }
}
