using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxLengthChainOfPairs
{
    class Program
    {
        static void FindMaxChain(int[,] arr)
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(0);
            for (int i = 1; i < arr.GetLength(0); i++)
            { 
                if(arr[i, 0] > arr[stk.Peek(), 1])
                {
                    stk.Push(i);
                }
            }

            while (stk.Count > 0)
            {
                Console.WriteLine("{0}, {1}", arr[stk.Peek(), 0], arr[stk.Peek(), 1]);
                stk.Pop();
            }
        }

        static void Main(string[] args)
        {
            int[,] arr = { 
                         {5, 24},
                         {15, 25},
                         {27, 40},
                         {50, 60}
                         };
            FindMaxChain(arr);
            Console.ReadLine();
        }
    }
}
