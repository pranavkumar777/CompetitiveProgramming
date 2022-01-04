using System;


namespace CompetitiveProgramming
{
   public class Program
    {
        public static void Main(string[] args)
        {
         
            GameOfLifeSolution gameOfLifeSolution = new GameOfLifeSolution();
            gameOfLifeSolution.SetInput();
            gameOfLifeSolution.ComputeLivingPositions();
            gameOfLifeSolution.DisplayLivingPositions();
            Console.ReadLine();
        }
    }
}
