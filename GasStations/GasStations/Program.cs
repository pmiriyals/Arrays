using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GasStations
{
    class Program
    {
        class station
        {
            public int gas { get; set; }
            public int dist { get; set; }
            public station(int gas, int dist)
            {
                this.gas = gas;
                this.dist = dist;
            }
        }

        static void FindStartOfTour(station[] stations)
        {
            if (stations == null || stations.Length < 2)
                return;

            int cur_gas = stations[0].gas - stations[0].dist;   //add first gas station to the tour
            int start = 0, end = 1;

            while (start != end || cur_gas < 0)
            {
                while (cur_gas < 0 && start != end) //if gas is < 0 and tour is still on, then remove this station from the tour
                {
                    cur_gas -= stations[start].gas - stations[start].dist;
                    start = (start + 1) % stations.Length;  //increment gas (circular array)

                    if (start == 0)
                        return; //if we came back to 1st station, then a tour cannot be formed
                }

                cur_gas += stations[end].gas - stations[end].dist;
                end = (end + 1) % stations.Length;
            }

            Console.WriteLine("Start = {0}\nEnd = {1}", start, end);
        }
        
        static void Main(string[] args)
        {
            int[,] mat = { 
                         {6, 4},
                         {0, 6},
                         {7, 3}
                         };
            station[] stations = new station[mat.GetLength(0)];

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                stations[i] = new station(mat[i, 0], mat[i, 1]);
            }

            FindStartOfTour(stations);
            Console.ReadLine();
        }
    }
}
