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
    public class KingTests
    {
        [DataTestMethod()]
        //(X - 1, Y - 1), (X, Y - 1), (X + 1, Y - 1), (X + 1, Y), (X + 1, Y + 1), (X, Y + 1), (X - 1, Y + 1), (X - 1, Y)
        [DataRow(0, 0, 0, 1)]
        [DataRow(0, 4, 0, 3, 0, 5)]
        [DataRow(7, 4, 6, 3, 6, 5, 6, 4)]
        public void GetAvailableMovesTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(6, Color.Black, places[0], places[1]);
            board[1, 7].PutNewFigure(2, Color.White, 1, 7);
            board[6, 4].PutNewFigure(4, Color.White, 6, 4);
            int i = 2;
            foreach ((int x, int y) in board[places[0], places[1]].figure.GetAvailableMoves(board))
            {

                Assert.AreEqual(places[i], x);
                Assert.AreEqual(places[i + 1], y);
                i += 2;
            }
        }
        [DataTestMethod()]
        [DataRow(0, 0, 1, 0, 1, 1, 0, 1)]
        [DataRow(0, 4, 0, 3, 1, 3, 1, 4, 0, 5)]
        public void GetDefendedSquaresTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(6, Color.Black, places[0], places[1]);
            board[1, 5].PutNewFigure(2, Color.White, 1, 5);
            int i = 2;
            foreach ((int x, int y) in board[places[0], places[1]].figure.GetDefendedSquares(board))
            {
                
                Assert.AreEqual(places[i], x);
                Assert.AreEqual(places[i + 1], y);
                i += 2;
            }
        }
    }
}