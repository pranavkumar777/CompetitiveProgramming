using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello");
            string row = Console.ReadLine();
            string column = Console.ReadLine();
            // convert to integer
            int m = Convert.ToInt32(row);
            int n = Convert.ToInt32(column);
            int[,] input = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    input[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(input[i, j]+" ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
