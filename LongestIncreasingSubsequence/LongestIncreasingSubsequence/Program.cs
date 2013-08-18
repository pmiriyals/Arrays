using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void LISSize(int[] arr)
        {
            int[] lis = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                lis[i] = 1; //n different sequences, with each seq of length 1

            int max = 1;
            bool isseq = false;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++) //compute lis[0 to i] = lis[0 to j] + 1 iff arr[i] > arr[j]
                {
                    if (arr[i] > arr[j] && (lis[i] < (lis[j] + 1)))
                    {
                        lis[i] = lis[j] + 1;
                        isseq = true;
                        Console.Write("{0} ", arr[j]);
                        if (max < lis[i])
                            max = lis[i];
                    }
                }
                if (isseq)
                {
                    Console.WriteLine("{0} ", arr[i]);
                    isseq = false;
                }
            }

            Console.WriteLine("\nLength of longest increasing subsequence = {0}", max);
        }

        static void Main(string[] args)
        {
            int[] arr = { 10, 22, 9, 33, 21, 50, 25};
            LISSize(arr);
            Console.ReadLine();
        }
    }
}
