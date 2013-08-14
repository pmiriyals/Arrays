using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergingIntervals
{
    class Program
    {
        class interval
        {
            public int start { get; set; }
            public int end { get; set; }
            public interval(int start, int end)
            {
                this.start = start;
                this.end = end;
            }            
        }

        static void MergeIntervals(interval[] intervals)
        {
            intervals = intervals.OrderBy(o => o.start).ToArray();
            Console.WriteLine("Intervals after sorting: ");
            foreach (interval i in intervals)
            {
                Console.WriteLine("({0}, {1})", i.start, i.end);
            }

            Stack<interval> stk = new Stack<interval>();
            stk.Push(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                if (stk.Count > 0)
                {
                    if (stk.Peek().end < intervals[i].start)
                        stk.Push(intervals[i]);
                    else if (stk.Peek().end < intervals[i].end)
                        stk.Peek().end = intervals[i].end;
                    else if (stk.Peek().end > intervals[i].end)
                        continue;
                }
                else
                    stk.Push(intervals[i]);                    
            }
            Console.WriteLine("\nIntervals after merging: ");
            while(stk.Count > 0)
            {
                interval inter = stk.Pop();
                Console.WriteLine("({0}, {1})", inter.start, inter.end);
            }
        }

        static void Main(string[] args)
        {
            interval[] intervals = { new interval(6, 8), new interval(1, 3), new interval(2, 4), new interval(4, 7) };
            MergeIntervals(intervals);
            Console.ReadLine();
        }
        
    }
}
