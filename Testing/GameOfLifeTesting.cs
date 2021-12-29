using System;
using System.Collections.Generic;
using GameOfLife;
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
            //Input set 1
            int gen = 3;
            currGen[2, 1] = 1;
            currGen[2, 2] = 1;
            currGen[2, 3] = 1;
            List<int> TestLivePositions = new List<int>() {
            12,22,32
            };
            GameOfLifeSolution gameOfLifeSolution = new GameOfLifeSolution();
            List<int> LivePositions = gameOfLifeSolution.ComputeLivingPositions(currGen, gen);
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
