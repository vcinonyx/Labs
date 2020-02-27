using System;
using System.Runtime.InteropServices;

namespace oop_laba1 {
public class BitOperations
    {   
        public void Increment(ref int i)
        {
            int mask = 1;
            while ((i&mask)!=0) 
            {   
                i &= ~mask; 
                mask <<= 1; 
            }
            i |= mask; 
        }


        public bool BitComparison(int a, int b)
        {
            int mask = 1;
            int size = sizeof(int) * 8;

            int signA = a&(mask << size-1); // SignA - знаковый бит.
            int signB = b&(mask << size-1);
            
            if (signA - signB > 0){
                return false;
            }

            if (signA - signB < 0){
                return true;
            }
            
            if (signA == signB) {
                for(int i = size - 2; i > 0; i--) 
                {
                    mask = 1 << i;
         
                    if (((b & mask) != 0) && ((a & mask) == 0)) //  b = 1; а = 0 ==> a < b  
                    {
                        return true;
                    }
                    if (((a & mask) != 0) && ((b & mask) == 0)) // a = 1;  b = 0 ==> a > b
                    {
                        return false;
                    }
                }
            }
            return false;
        }    
    }

    class Program
    {
        public static void Main()
        {
            BitOperations obj = new BitOperations();
            int i1 = 63;    int i2 = -128;  int i3 = 45;
            obj.Increment(ref i1);
            obj.Increment(ref i2);
            obj.Increment(ref i3);
            bool res1 = obj.BitComparison(33, 117);
            bool res2 = obj.BitComparison(-6, -10);
            bool res3 = obj.BitComparison(26, 26); 
        }
    }
}