using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StableMarriage
{
    class Program
    {
        //1. Use a preference matrix for preference list of men and women
        //2. Men are rep from 0 to n-1 and women are from n to 2n-1. Hence matrix will be mat[2n, n], 0 to n-1 rows for men and n to 2n-1 rows for women and each row is a preference list for that particular man or women
        //3. Declare an array wPartner, where each ndx in arr corresponds to a women (ndx + n) and element assigned corresponds to their partner (men).
        //4. Declare a list of free men. Pick the free man from 0th element and remove it from list while assigning a partner.
        //5. Iterate over man's preference list, if the 1st women has no partner assigned yet, then engage them.
        //6. If the 1st women has a partner already, then check if this women prefers the current man over her partner. If yes, then remove her partner and add back to free men list and engage this women with cur man.
        //7. For every engagement decrease the count of free men and when the count reaches 0, end the loop
        
        static void FindMatch(int[,] prefer)
        {
            int n = prefer.GetLength(1);    //0 to N-1 are men and N to 2N-1 are women
            List<int> men = new List<int>();
            for (int i = 0; i < n; i++)
                men.Add(i); //list of free men (not yet engaged)

            int[] wPartner = new int[n];
            for (int i = 0; i < n; i++)
                wPartner[i] = -1;   //index corresponds to women and element corresponds to their partner

            while (men.Count > 0)
            {
                int m = men[0];
                men.RemoveAt(0);    //this men will be assigned partner now. Hence remove from list.

                for (int i = 0; i < n; i++)
                {
                    int w = prefer[m, i];

                    if (wPartner[w - n] == -1)  //given 8x4 matrix, our n is 4, but w can be anywhere between n to 2n-1, that is 4 to 7 incl.
                    {
                        wPartner[w - n] = m;
                        break;
                    }
                    else
                    {
                        if (wPrefersm(prefer, w, m, wPartner[w-n]))
                        {
                            men.Add(wPartner[w - n]);   //add back current partner of w to free men list
                            wPartner[w - n] = m;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Man{0} married to Women{1}", wPartner[i], i + n);
            }
        }

        static bool wPrefersm(int[,] prefer, int w, int m, int curM)
        {
            for (int i = 0; i < prefer.GetLength(1); i++)
            {
                if (prefer[w, i] == m)
                    return true;

                if (prefer[w, i] == curM)
                    return false;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int[,] prefer = { {7, 5, 6, 4},
                                {5, 4, 6, 7},
                                {4, 5, 6, 7},
                                {4, 5, 6, 7},
                                {0, 1, 2, 3},
                                {0, 1, 2, 3},
                                {0, 1, 2, 3},
                                {0, 1, 2, 3},
                            };

            FindMatch(prefer);
            Console.ReadLine();
        }
    }
}
