using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class PrintDiagnolly
    {
        static void printDiagnolly(int[,] mat)
        {
            int M = mat.GetLength(0);
            int N = mat.GetLength(1);

            for (int line = 1; line <= (M + N - 1); line++)
            {
                int col = Math.Max(0, line - M);
                int row = Math.Min(line - 1, M - 1);

                while (row >= 0 && col < N)
                {
                    Console.Write("{0} ", mat[row, col]);
                    row--;
                    col++;
                }
                Console.WriteLine();
            }
        }

        public static void driver()
        {
            int[,] mat = new int[5, 4];
            int val = 1;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = val++;
                }
            }

            printDiagnolly(mat);            
        }

        static void printMatrix(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
