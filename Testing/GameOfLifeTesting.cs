using System;
using System.Collections.Generic;
using CompetitiveProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class GameOfLifeTesting
    {
        [TestMethod]
        public void GameofLifeTestCase()
        {
            int[,] currGen = new int[25, 25];
            bool success = true;
            List<int> TestLivePositions = new List<int>() {
            12,22,32
            };
            GameOfLifeSolution gameOfLifeSolution = new GameOfLifeSolution();
            gameOfLifeSolution.SetInput();
            List<int> LivePositions = gameOfLifeSolution.ComputeLivingPositions();
            for (int i = 0; i < LivePositions.Count; i++)
            {
                if (!TestLivePositions.Contains(LivePositions[i]))
                {
                    success = false;
                }
            }
            Assert.IsTrue(success);
        }
    }
}
