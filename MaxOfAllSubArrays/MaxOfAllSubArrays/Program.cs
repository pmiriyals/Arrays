using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxOfAllSubArrays
{
    class Program
    {
        //Time: O(n)
        //Not working. Need to implement a custom double ended queue.
        static void FindMaxOfEachSubArr(int[] arr, int k)
        {
            Queue<int> queue = new Queue<int>();    //To store indexes of array

            int i;
            //Process 1st k items in array
            for(i = 0; i < k; i++)
            {
                if(queue.Count == 0 || queue.Peek() < arr[i])
                    queue.Enqueue(i);
            }

            for (; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[queue.Peek()]);

                while (queue.Count > 0 && queue.Peek() <= (i - k))
                    queue.Dequeue();
                //need a double ended queue
                //while (queue.Count > 0 && arr[i] >= arr[queue.back()])
                  //  queue.DequeueBack();
                queue.Enqueue(i);
            }

            Console.Write("{0} ", arr[queue.Peek()]);//for last window
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 1, 4, 5, 2, 3, 6 };
        }
    }
}
