using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LengthOfLongestIncrSubSeq
{
    class Program
    {
        static void LIS(int[] arr)
        {
            int[] lis = new int[arr.Length];
            lis[0] = arr[0];
            int len = 1;

            for(int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < lis[0])
                    lis[0] = arr[i];
                else if (arr[i] > lis[len - 1])
                {
                    lis[len++] = arr[i];
                    printArr(lis, len);
                }
                else
                    lis[CeilIndex(lis, -1, len - 1, arr[i])] = arr[i];
            }

            Console.WriteLine("Length of LIS = {0}", len);
            Console.WriteLine("LIS elements: ");
            foreach (int i in lis)
                Console.Write("{0} ", i);
        }

        static void printArr(int[] lis, int len)
        {
            Console.WriteLine();
            for (int i = 0; i < len; i++)
                Console.Write("{0} ", lis[i]);
        }

        static int CeilIndex(int[] arr, int low, int high, int key)
        {
            while (high - low > 1)
            {
                int m = low + (high - low) / 2;

                if (arr[m] >= key)
                    high = m;
                else
                    low = m;
            }

            return high;
        }

        static void Main(string[] args)
        {
            int[] arr = { 2, 5, 3, 7, 11, 8, 10, 13, 6 };
            LIS(arr);
            Console.ReadLine();
        }
    }
}
