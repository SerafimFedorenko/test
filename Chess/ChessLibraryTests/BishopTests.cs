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
    public class BishopTests
    {

        [DataTestMethod()]
        [DataRow(0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7)]
        [DataRow(0, 7, 1, 6, 2, 5, 3, 4, 4, 3, 5, 2, 6, 1, 7, 0)]
        [DataRow(7, 7, 6, 6, 5, 5, 4, 4, 3, 3, 2, 2, 1, 1, 0, 0)]
        [DataRow(3, 2, 2, 1, 1, 0, 4, 1, 5, 0, 4, 3, 5, 4, 2, 3, 1, 4)]
        public void GetAvailableMovesTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(4, Color.Black, places[0], places[1]);
            board[7, 0].PutNewFigure(3, Color.White, 7, 0);
            board[1, 4].PutNewFigure(4, Color.White, 1, 4);
            board[6, 5].PutNewFigure(1, Color.Black, 6, 5);
            int i = 2;
            foreach ((int x, int y) in board[places[0], places[1]].figure.GetAvailableMoves(board))
            {
                Assert.AreEqual(places[i], x);
                Assert.AreEqual(places[i + 1], y);
                i += 2;
            }
        }
        [DataTestMethod()]
        [DataRow(0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7)]
        [DataRow(0, 7, 1, 6, 2, 5, 3, 4, 4, 3, 5, 2, 6, 1)]
        [DataRow(7, 7, 6, 6, 5, 5, 4, 4, 3, 3, 2, 2, 1, 1, 0, 0)]
        [DataRow(3, 2, 2, 1, 1, 0, 4, 1, 5, 0, 4, 3, 5, 4, 6, 5, 2, 3)]
        public void GetDefendedSquaresTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(4, Color.Black, places[0], places[1]);
            board[7, 0].PutNewFigure(3, Color.White, 7, 0);
            board[1, 4].PutNewFigure(4, Color.White, 1, 4);
            board[6, 5].PutNewFigure(1, Color.Black, 6, 5);
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