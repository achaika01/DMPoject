using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmProject
{
    public static class PrintMatrix
    {
        public static void PrintM(int[,] reachability)
        {
            int n = reachability.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(reachability[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
