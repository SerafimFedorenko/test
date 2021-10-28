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
    public class PawnTests
    {
        [DataTestMethod()]
        [DataRow(0, 1, 0, 2, 0, 3)]
        [DataRow(1, 1, 1, 2, 1, 3)]
        [DataRow(0, 6, 0, 5, 0, 4)]
        public void PawnGetAvailableMovesTest(params int[] places)
        {
            Board board = new Board();
            board.StartPlacement();
            int i = 2;
            foreach ((int x, int y) in board[places[0], places[1]].figure.GetAvailableMoves(board))
            {
                Assert.AreEqual(places[i], x);
                Assert.AreEqual(places[i + 1], y);
                i += 2; 
            }
        }
    }
}