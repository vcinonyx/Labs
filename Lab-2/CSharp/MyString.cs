using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    public class Line
    {

        public char[] str;

        public Line(string istr)
        {
            str = istr.ToCharArray();
        }

        public int FindSubStr(char[] substr)
        {
            int flag;
            int counter = 0;
            for(int i = 0; i < this.str.Length; i++)
            {
                if (substr[0] == this.str[i])
                {
                    if (i + substr.Length <= this.str.Length)
                    {
                        flag = 1;
                        char[] copyStr = new char[substr.Length];
                        for (int l = 0; l < substr.Length; l++)
                        {
                            copyStr[l] = this.str[l + i];
                        }
                        for (int m = 0; m < substr.Length; m++)
                        {
                            if (substr[m] != copyStr[m])
                            {
                                flag = 0;
                                break;
                            }
                        }
                        if (flag != 0)
                        {
                            counter ++;
                        }
                    }
                }
            }
            return counter;
        }

        public void CharReplace(string a, string b)
        {
            char[] sub1 = a.ToCharArray();
            char[] sub2 = b.ToCharArray();
            for(int i = 0; i<str.Length; i++)
            {
                if(str[i] == sub1[0])
                {
                    str[i] = sub2[0];
                }
            }
        }
    }


}