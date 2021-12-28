using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameOfLifeSolution
    {
        //Neighbour positions
        int[] x = { 0, 1, 1, 1, 0, -1, -1, -1 };
        int[] y = { -1, -1, 0, 1, 1, 1, 0, -1 };

        // Check whether neighbour coordinates are valid
        private bool isValidNeighbour(int x, int y)
        {
            if (x > 24 || x < 0 || y < 0 || y > 24)
                return false;

            return true;
        }

        private int[,] ComputeNextGeneration(int[,] nextGen, int[,] currGen)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    int liveneighbour = 0;
                    for (int k = 0; k < 8; k++)
                    {
                        //Check whether neighbour position is valid
                        bool valid = isValidNeighbour(i + x[k], j + y[k]);
                        if (valid && (currGen[i + x[k], j + y[k]] == 1))
                        {
                            liveneighbour++;
                        }

                    }
                    if (currGen[i, j] == 1 && (liveneighbour < 2 || liveneighbour > 3))
                    {
                        nextGen[i, j] = 0;
                    }
                    if (currGen[i, j] == 0 && (liveneighbour == 3))
                    {
                        nextGen[i, j] = 1;
                    }
                }
            }
            return nextGen;
        }

        private void DisplayCurrentGeneration(int[,] currGen)
        {

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    Console.Write(currGen[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        public List<int> ComputeLivingPositions(int[,] currGen, int generations)
        {
            List<int> livePositions = new List<int>();
            try
            {
               
                int[,] nextGen = new int[25, 25];
                //copying currGen to nextGen
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {

                        nextGen[i, j] = currGen[i, j];
                    }
                }

                Console.WriteLine();

                int iterations = 1;
                while (iterations <= generations)
                {
                  nextGen =  ComputeNextGeneration(nextGen, currGen);

                    //Updating current generation to compute next generation 
                    for (int i = 0; i < 25; i++)
                    {
                        for (int j = 0; j < 25; j++)
                        {
                            currGen[i, j] = nextGen[i, j];
                        }
                    }
                    iterations++;
                }


                //print required generation
                Console.WriteLine("The live cells in the " + generations + " generation are below:");
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (nextGen[i, j] == 1)
                        {
                            string x = i.ToString();
                            string y = j.ToString();
                            livePositions.Add(int.Parse(x+y));
                            Console.WriteLine("(" + i + "," + j + ")");
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occured" + e);
            }
            return livePositions;
        }

       public static void Main(string[] args)
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


            GameOfLifeSolution program = new GameOfLifeSolution();
            program.ComputeLivingPositions(input, gen);
            Console.ReadLine();
        }
    }
}
