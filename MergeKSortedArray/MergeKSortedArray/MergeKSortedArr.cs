using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeKSortedArray
{
    class MergeKSortedArr
    {
        private static int max = 1000;
        
        class Node
        {
            public int data { get; set; }
            public int i { get; set; }
            public int j { get; set; }

            public Node(int data) : this(data, -1, -1) { }
            public Node(int data, int i, int j)
            {
                this.data = data;
                this.i = i;
                this.j = j;
            }
        }

        private static void heapify(Node[] a, int end)
        {
            int start = (end - 2) / 2;  //Get last parent in the array
            while (start >= 0)
            {
                siftDown(a, start, end - 1);
                start--;
            }
        }

        private static void siftDown(Node[] a, int start, int end)
        {
            int root = start;
            
            while ((2*root + 1) <= end)
            {
                int child = 2 * root + 1;
                int swap = root;

                if (a[swap].data > a[child].data)
                    swap = child;

                if ((child + 1) <= end && a[swap].data > a[child + 1].data)
                    swap = child + 1;

                if (root != swap)
                {
                    Node r = a[root];
                    a[root] = a[swap];
                    a[swap] = r;
                }
                else
                    return;
            }
        }
        
        public static void merge(int[,] arr)
        {
            int k = arr.GetLength(0);
            Node[] minHeap = new Node[k];
            //int[] minHeap = new int[k];

            for (int i = 0; i < k; i++)
            {
                minHeap[i] = new Node(arr[i, 0], i, 0);
            }
            heapify(minHeap, minHeap.Length);

            int m = arr.GetLength(1);
            int[] mergedArr = new int[k * m];
            int j = 0;

            while (j < mergedArr.Length)
            {
                mergedArr[j++] = minHeap[0].data;
                if (minHeap[0].j + 1 < arr.GetLength(1))
                {
                    minHeap[0].data = arr[minHeap[0].i, minHeap[0].j + 1]; //new Node(arr[minHeap[0].i, minHeap[0].j + 1], minHeap[0].i, minHeap[0].j + 1);
                    minHeap[0].i = minHeap[0].i;
                    minHeap[0].j = minHeap[0].j + 1;
                }
                else
                {
                    minHeap[0].data = max;
                    //for (int i = 1; i < minHeap.Length; i++)
                    //{
                    //    if (minHeap[i].j + 1 < arr.GetLength(1))
                    //    {
                    //        minHeap[0] = new Node(arr[minHeap[i].i, minHeap[i].j + 1], minHeap[i].i, minHeap[i].j + 1);
                    //        break;
                    //    }
                    //}
                }

                heapify(minHeap, minHeap.Length);
            }

            foreach (int num in mergedArr)
            {
                Console.Write("{0} ", num);
            }
        }

        public static void driver()
        {
            int[,] arr = { 
                         {1, 3, 5, 7},
                         {2, 4, 6, 8},
                         {0, 9, 10, 11}
                         };

            merge(arr);            
        }
    }
}
