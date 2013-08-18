using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountTriangles
{
    class Program
    {
        static void CountTrainglesPossible(int[] arr)
        {
            Array.Sort(arr);
            int cnt = 0;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int k = j + 1;
                    while (k < arr.Length && (arr[i] + arr[j]) > arr[k])
                        k++;

                    cnt += k - j - 1;   //j+1 to k-1 are possible triangles
                }
            }

            Console.WriteLine("Total tirangles = {0}", cnt);
        }

        static void Main(string[] args)
        {
            int[] arr = { 10, 21, 22, 100, 101, 200, 300};
            CountTrainglesPossible(arr);
            Console.ReadLine();
        }
    }
}
