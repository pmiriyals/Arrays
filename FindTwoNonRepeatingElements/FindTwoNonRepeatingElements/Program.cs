using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindTwoNonRepeatingElements
{
    class Program
    {
        static void FindTwoNRElemenst(int[] arr)
        {
            int x = 0, y = 0;
            int xor = arr[0];
            int setbit;
            
            for(int i = 1; i < arr.Length; i++)
                xor ^= arr[i];  //This will be xor between two unqiue elements in the array, as other elements cancel out

            setbit = xor & ~(xor-1);    //get the rightmost set bit, we can chose any set bit from xor
            for(int i = 0; i < arr.Length; i++)
            {
                if((setbit & arr[i]) > 0)   //Divide elements in arr into two sets, a set which has 1 in the same posn as setbit (all same elements + 1 unique element will fall in each set)
                    x ^= arr[i];
                else
                    y ^= arr[i];
            }
            Console.WriteLine("x = {0}\ny = {1}", x, y);
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 2, 1, 9, 3 };
            FindTwoNRElemenst(arr);
            Console.ReadLine();
        }
    }
}
