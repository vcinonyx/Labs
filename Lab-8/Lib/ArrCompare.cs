using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class ArrCompare
    {
        public delegate bool EqualityHandler(double[] arr1, double[] arr2, int index);
        public static bool CompareStatic(double[] arr1, double[] arr2, int index)
        {
            if ((index < arr1.Length) && (index >= 0)) 
            {
                return arr1[index] == arr2[index];
            }
            throw new ArgumentOutOfRangeException("Index is out of range");
        }
        public bool CompareExemplary(double[] arr1, double[] arr2, int index)
        {
            if ((index < arr1.Length) && (index >= 0))
            {
                return arr1[index] == arr2[index];
            }
            throw new ArgumentOutOfRangeException("Index is out of range");
        }
    }
}
