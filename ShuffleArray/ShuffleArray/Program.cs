using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuffleArray
{
    class Program
    {
        static void Shuffle(int[] arr)
        {
            Console.Write("Array before shuffling: ");
            foreach (int i in arr)
                Console.Write("{0} ", i);
            Console.WriteLine("\n");

            Random r = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                int j = r.Next(0, i+1);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            Console.Write("Array after shuffling:  ");
            foreach (int i in arr)
                Console.Write("{0} ", i);
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            Shuffle(arr);
            Console.ReadLine();
        }
    }
}
