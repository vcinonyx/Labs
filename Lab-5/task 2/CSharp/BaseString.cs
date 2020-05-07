using System;

namespace CSharp
{
    public class BaseString
    {
        protected char[] StrValue { get; set; }
        public BaseString(params char[] str)
        {
            StrValue = str;
        }
        public virtual int GetLength() => 0;

        public virtual int FindChar(char c)
        {
            int counter = 0;
            for (int i = 0; i < StrValue.Length; i++)
            {
                if (StrValue[i] == c)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
