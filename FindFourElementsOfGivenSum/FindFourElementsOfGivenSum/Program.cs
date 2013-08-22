using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindFourElementsOfGivenSum
{
    class Program
    {
        class aux
        {
            public int sum { get; set; }
            public int a { get; set; }
            public int b { get; set; }
            public aux(int a, int b)
            {
                this.a = a;
                this.b = b;
                this.sum = a + b;
            }
        }

        static void FindSum(int[] arr, int K)
        { 
            int n = arr.Length;
            aux[] Aux = new aux[n * (n - 1) / 2];

            int ndx = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    Aux[ndx++] = new aux(arr[i], arr[j]);
                }
            }

            //Aux = Aux.OrderBy(o => o.sum).ToArray(); //We can use sorting if we are not allowed to use extra space like dictionary, in which case sort the Aux array and use two pointers i = 0, j = aux.Length
            //and then increment/decrement i, j according to the sum
            Dictionary<int, aux> dict =new Dictionary<int,aux>();
            
            foreach (aux pairSum in Aux)
            {
                if (dict.ContainsKey(K - pairSum.sum))
                {
                    Console.WriteLine("Found four elements: {0}, {1}, {2}, {3}", pairSum.a, pairSum.b, dict[K - pairSum.sum].a, dict[K - pairSum.sum].b);
                    break;
                }
                if(!dict.ContainsKey(pairSum.sum))
                    dict.Add(pairSum.sum, pairSum);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 30, 40, 1, 2 };
            FindSum(arr, 91);
            Console.ReadLine();
        }
    }
}
