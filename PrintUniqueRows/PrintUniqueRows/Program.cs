using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintUniqueRows
{
    class Program
    {
        static void printUniqueRows(int[,] mat)
        {            
            HashSet<string> hs = new HashSet<string>();
           
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                string s = "";

                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    s += mat[i, j].ToString() + " ";
                }
                if (!hs.Contains(s))
                {
                    Console.WriteLine(s);
                    hs.Add(s);
                }
            }
        }

        static void printUniqueRowsUsingNum(int[,] mat)
        {
            HashSet<int> hs = new HashSet<int>();
            
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                int num = 0;
                string s = "";
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    num = (num * 10) + mat[i, j];
                    s += mat[i, j].ToString() + " ";
                }
                if (!hs.Contains(num))
                {
                    Console.WriteLine(s);
                    hs.Add(num);
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] mat = { 
                         {0, 1, 0, 0, 1},
                         {1, 0, 1, 1, 0},
                         {0, 1, 0, 0, 1},
                         {1, 1, 1, 0, 0}
                         };
            //printUniqueRows(mat);
            printUniqueRowsUsingNum(mat);
            Console.ReadLine();
        }
    }
}
