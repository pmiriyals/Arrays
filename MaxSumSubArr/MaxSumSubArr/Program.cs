using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxSumSubMatrix
{
    class Program
    {
        static int Kadane(int[] arr, out int start, out int end)
        {
            start = -1;
            end = -1;

            if (arr == null || arr.Length <= 0)
            {                
                return -1;
            }
            int strt = 0;

            int maxSum = 0;
            int maxSoFar = 0;
            int min = Int32.MinValue;
            int mini = 0;
            bool isallNeg = true;

            for (int i = 0; i < arr.Length; i++)
            {
                maxSoFar += arr[i];

                if (maxSoFar < 0)
                {
                    maxSoFar = 0;
                    strt = i + 1;
                    if (isallNeg && min < arr[i])
                    {
                        min = arr[i];
                        mini = i;
                    }
                }
                else if (maxSoFar > maxSum)
                {
                    isallNeg = false;
                    maxSum = maxSoFar;
                    start = strt;
                    end = i;
                }
            }

            if (isallNeg)
            {
                start = mini;
                end = mini;
                maxSum = min;
            }

            return maxSum;
        }

        static void MaxSumSubMat(int[,] mat)
        {
            int fl = 0, fr = 0, ft = 0, fb = 0, start, end;
            int[] temp;
            int maxSum = Int32.MinValue;

            for (int left = 0; left < mat.GetLength(1); left++)
            {
                temp = new int[mat.GetLength(0)];

                for (int right = left; right < mat.GetLength(1); right++)
                {
                    for (int i = 0; i < mat.GetLength(0); i++)
                        temp[i] += mat[i, right];

                    int curMax = Kadane(temp, out start, out end);

                    if (curMax > maxSum)
                    {
                        maxSum = curMax;
                        fl = left;
                        fr = right;
                        ft = start;
                        fb = end;
                    }
                }
            }
            Console.WriteLine("Max sum = {0}\n", maxSum);
            printMaxSubMatrix(mat, fl, fr, ft, fb);
        }

        static void printMaxSubMatrix(int[,] mat, int fl, int fr, int ft, int fb)
        {
            Console.WriteLine("Max Sum Sub Matrix: ");
            for (int i = ft; i <= fb; i++)
            {
                for (int j = fl; j <= fr; j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] mat = { 
                         {1, 2, -1, -4, -20},
                         {-8, -3, 4, 2, 1},
                         {3, 8, 10, 1, 3},
                         {-4, -1, 1, 7, -6}
                         };

            MaxSumSubMat(mat);
            Console.ReadLine();
        }
    }
}
