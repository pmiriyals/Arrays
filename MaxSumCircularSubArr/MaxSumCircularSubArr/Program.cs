using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxSumCircularSubArr
{
    class Program
    {
        static int Kadane(int[] arr)
        {
            int maxFoundSoFar = 0;
            int maxTillHere = 0;
            bool isAllNeg = true;
            int minNeg = Int32.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                maxTillHere += arr[i];
                if (maxTillHere < 0)
                {
                    maxTillHere = 0;
                    if (isAllNeg && minNeg < arr[i])
                        minNeg = arr[i];
                }
                else if (isAllNeg)
                    isAllNeg = false;

                if (maxTillHere > maxFoundSoFar)
                    maxFoundSoFar = maxTillHere;
            }
            Console.WriteLine("MaxFoundSoFar using Kadane's algorithm = {0}", maxFoundSoFar);

            return maxFoundSoFar;
        }

        static void MaxSumCirCularArr(int[] arr)
        {
            int totalSum = 0, maxSumSubArr = 0, invertedMaxSum;

            for (int i = 0; i < arr.Length; i++)
            {
                totalSum += arr[i];
                arr[i] = -arr[i];
            }

            invertedMaxSum = Kadane(arr);

            maxSumSubArr = totalSum + invertedMaxSum;   //(totalSum - Sum of subarray which is not part of max sum sub arr
            Console.WriteLine("Max Sum in a circular sub array = {0}", maxSumSubArr);
        }

        static void Main(string[] args)
        {
            int[] arr = { 8, -8, 9, -9, 10, -11, 12 };
            MaxSumCirCularArr(arr);
            Console.ReadLine();
        }
    }
}
