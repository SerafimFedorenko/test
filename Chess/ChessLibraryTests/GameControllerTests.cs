using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Tests
{
    [TestClass()]
    public class GameControllerTests
    {
        /// <summary>
        /// Rezult of test in text file
        /// </summary>
        [DataTestMethod()]
        //Mate of fool to black
        //The first move is impossible
        [DataRow(4, 1, 4, 6, 4, 1, 4, 2, 5, 6, 5, 5, 3, 1, 3, 2, 6, 6, 6, 4, 3, 0, 7, 4)]
        //Mate of fool to white
        [DataRow(5, 1, 5, 2, 4, 6, 4, 5, 6, 1, 6, 3, 3, 7, 7, 3)]
        [DataRow(4, 1, 4, 3, 4, 6, 4, 4, 5, 0, 2, 3, 1, 7, 2, 5, 3, 0, 7, 4, 6, 7, 5, 5, 7, 4, 5, 6)]
        public void TurnToMoveTest(params int[] moves)
        {
            GameController game = new GameController();
            for (int i = 0; i < moves.Length; i += 4)
            {
                game.TurnToMove(moves[i], moves[i + 1], moves[i + 2], moves[i + 3]);
            }
        }
    }
}