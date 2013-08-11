using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindPivotInRotatedSortedArr
{
    class Program
    {
        static void FindPivot(int[] arr)
        {
            int min = BinSearchPivot(arr, 0, arr.Length - 1);
            int max = BinSearchMaxPivot(arr, 0, arr.Length - 1);
            if (min < 0)
                Console.WriteLine("Pivot does not exist");
            else
                Console.WriteLine("Min = {0}\nMax = {1}", min, max);
        }

        //Avg Case O(log n) (that is when there are no duplicates as shown below)
        //Worst Case O(n) (in case of duplicates in a special way)
        static int BinSearchMaxPivot(int[] arr, int left, int right)
        {
            if (left > right)
                return arr[arr.Length -1];

            if (left == right)
                return arr[right];

            int mid = left + (right - left) / 2;

            if (mid > left && arr[mid] < arr[mid - 1])
                return arr[mid - 1]; //found pivot

            if (mid < right && arr[mid] > arr[mid + 1])
                return arr[mid];
            //In case of duplicates as the array below, we need to check both halves and find the min element
            //This takes O(n)
            if (arr[left] == arr[mid] && arr[right] == arr[mid])
                return Math.Max(BinSearchPivot(arr, left, mid - 1), BinSearchPivot(arr, mid + 1, right));

            if (arr[right] > arr[mid])
                return BinSearchPivot(arr, left, mid - 1);
            return BinSearchPivot(arr, mid + 1, right);
        }

        //Avg Case O(log n) (that is when there are no duplicates as shown below)
        //Worst Case O(n) (in case of duplicates in a special way)
        static int BinSearchPivot(int[] arr, int left, int right)
        {
            if (left > right)
                return arr[0];

            if (left == right)
                return arr[left];

            int mid = left + (right - left) / 2;
            
            if (mid > left && arr[mid] < arr[mid - 1])
                return arr[mid]; //found pivot

            if (mid < right && arr[mid] > arr[mid + 1])
                return arr[mid + 1];
            //In case of duplicates as the array below, we need to check both halves and find the min element
            //This takes O(n)
            if (arr[left] == arr[mid] && arr[right] == arr[mid])
                return Math.Min(BinSearchPivot(arr, left, mid - 1), BinSearchPivot(arr, mid + 1, right));

            if(arr[right] > arr[mid])
                return BinSearchPivot(arr, left, mid - 1);
            return BinSearchPivot(arr, mid + 1, right);
        }
        
        static void Main(string[] args)
        {
            int[] arr = { 2, 2, 2, 0, 2, 2, 2, 2, 2, 2 };
            FindPivot(arr);
            Console.ReadLine();
        }
    }
}
