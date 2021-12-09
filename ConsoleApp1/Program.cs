using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // Check whether neighbour coordinates are valid
        public bool isValid(int x,int y)
        {
            if(x>24 || x<0 || y <0 || y>24)
                return false;

            return true;
        }

        public void OutputLive(int[,] input, int gen)
        {
            try
            {
                //Neighbour positions
                int[] x = { 0, 1, 1, 1, 0, -1, -1, -1 };
                int[] y = { -1, -1, 0, 1, 1, 1, 0, -1 };

                int[,] output = new int[25,25];
               
                //copying input to output
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                       
                        output[i, j] = input[i, j];
                    }
                }

                Console.WriteLine();

                int iterations = 1;
                while (iterations <= gen)
                {
                    for (int i = 0; i < 25; i++)
                    {
                        for (int j = 0; j < 25; j++)
                        {
                            int liveneighbour = 0;
                            for (int k = 0; k < 8; k++)
                            {
                                //Check whether neighbour position is valid
                                bool valid = isValid(i + x[k], j + y[k]);
                                if (valid && (input[i + x[k], j + y[k]] == 1))
                                {
                                    liveneighbour++;
                                }

                            }
                            if (input[i, j] == 1 && (liveneighbour < 2 || liveneighbour > 3))
                            {
                                output[i, j] = 0;
                            }
                            if (input[i, j] == 0 && (liveneighbour == 3))
                            {
                                output[i, j] = 1;
                            }
                        }
                    }


                    // Uncomment to print next generation
                    //for (int i = 0; i < 25; i++)
                    //{
                    //    for (int j = 0; j < 25; j++)
                    //    {
                    //        //if (output[i, j] == 1)
                    //        //{
                    //        //    Console.WriteLine("(" + i + "," + j + ")");
                    //        //}
                    //        Console.Write(output[i, j] + " ");
                    //    }
                    //    Console.WriteLine();
                    //}

                    Console.WriteLine();

                    //set Input for next generation 
                    for (int i = 0; i < 25; i++)
                    {
                        for (int j = 0; j < 25; j++)
                        {                            
                            input[i, j] = output[i, j];
                        }
                    }
                    iterations++;
                }

                //print required generation
                Console.WriteLine("The live cells in the " + gen + " generation are below:");
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (output[i, j] == 1)
                        {
                            Console.WriteLine("(" + i + "," + j + ")");
                        }
                    }
                }
            }

            catch(Exception e)
            {
                Console.WriteLine("Exception occured" + e);
            }
          
        }

        static void Main(string[] args)
        {


            int[,] input = new int[25, 25];

            //Input set 1
            int gen = 3;
            input[2, 1] = 1;
            input[2, 2] = 1;
            input[2, 3] = 1;

            //Input set 2
            //int gen = 5;
            //input[9, 8] = 1;
            //input[10, 9] = 1;
            //input[8, 10] = 1;
            //input[9, 10] = 1;
            //input[10, 10] = 1;

            //Input set 3
            //int gen = 10;
            //input[1, 2] = 1;
            //input[2, 1] = 1;
            //input[2, 3] = 1;
            //input[3, 2] = 1;


            Program program = new Program();
            program.OutputLive(input,gen);
            Console.ReadLine();
        }
    }
}
