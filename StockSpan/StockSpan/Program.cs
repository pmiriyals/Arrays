using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSpan
{
    class Program
    {
        static void StockSpan(int[] price)
        {
            Stack<int> stk = new Stack<int>();  //push indexes
            stk.Push(0);
            int[] span = new int[price.Length];
            span[0] = 1;

            for (int i = 1; i < price.Length; i++)
            {
                while (stk.Count > 0 && price[stk.Peek()] < price[i])
                    stk.Pop();

                span[i] = (stk.Count == 0) ? i + 1 : (i - stk.Peek());
                stk.Push(i);
            }

            for (int i = 0; i < price.Length; i++)
            {
                Console.WriteLine("price: {0}\nspan: {1}\n", price[i], span[i]);
            }
        }

        static void Main(string[] args)
        {
            int[] price = { 10, 4, 5, 90, 120, 80 };
            StockSpan(price);
            Console.ReadLine();
        }
    }
}
