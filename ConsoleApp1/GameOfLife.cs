using System;
using System.Collections.Generic;

namespace CompetitiveProgramming
{
    public class GameOfLifeSolution
    {
        //Variables Declaration
        private int[,] nextGen = new int[25, 25];
        private List<int> livePositions = new List<int>();
        private int[,] currGen = new int[25, 25];
        private int generations { get; set; }

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

        //Display living and dead positions of current generations
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

        public void DisplayLivingPositions()
        {
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
                        livePositions.Add(int.Parse(x + y));
                        Console.WriteLine("(" + i + "," + j + ")");
                    }
                }
            }
        }

        //Compute Living positions upto required generation
        public List<int> ComputeLivingPositions()
        {          
            try
            {                               
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
                
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occured" + e);
            }
            return livePositions;
        }

        public void SetInput()
        {
            // TO DO : Set Dynamic input from user

            //Input set 1
            generations = 3;
            currGen[2, 1] = 1;
            currGen[2, 2] = 1;
            currGen[2, 3] = 1;

            //Input set 2
            //generations = 5;
            //currGen[9, 8] = 1;
            //currGen[10, 9] = 1;
            //currGen[8, 10] = 1;
            //currGen[9, 10] = 1;
            //currGen[10, 10] = 1;

            //Input set 3
            //generations = 10;
            //currGen[1, 2] = 1;
            //currGen[2, 1] = 1;
            //currGen[2, 3] = 1;
            //currGen[3, 2] = 1;
        }

    }
}
