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
    public class BoardTests
    {
        [TestMethod()]
        [DataRow(0, 0, false, Color.Black)]
        [DataRow(0, 7, true, Color.Black)]
        [DataRow(7, 0, true, Color.Black)]
        [DataRow(7, 3, true, Color.Black)]
        [DataRow(6, 6, true, Color.Black)]
        [DataRow(6, 5, true, Color.Black)]
        [DataRow(4, 6, false, Color.Black)]
        [DataRow(6, 5, false, Color.White)]
        [DataRow(5, 5, true, Color.White)]
        [DataRow(7, 7, true, Color.Black)]
        [DataRow(7, 7, false, Color.White)]
        public void IsSquareDefendedTest(int x, int y, bool expAttaked, Color color)
        {
            Board board = new Board();
            board[7, 7].PutNewFigure(5, Color.Black, 7, 7);
            board[7, 5].PutNewFigure(2, Color.Black, 7, 5);
            board[0, 0].PutNewFigure(4, Color.White, 0, 0);
            bool IsAttaked = board.IsSquareDefended(x, y, color);
            Assert.AreEqual(IsAttaked, expAttaked);
        }

        [TestMethod()]
        [DataRow(0, 0, true, Color.Black)]
        [DataRow(0, 7, true, Color.Black)]
        [DataRow(7, 0, true, Color.Black)]
        [DataRow(7, 3, true, Color.Black)]
        [DataRow(6, 6, true, Color.Black)]
        [DataRow(6, 5, true, Color.Black)]
        [DataRow(4, 6, false, Color.Black)]
        [DataRow(6, 5, false, Color.White)]
        [DataRow(5, 5, true, Color.White)]
        [DataRow(7, 7, false, Color.Black)]
        [DataRow(7, 7, true, Color.White)]
        public void IsSquareAttackedTest(int x, int y, bool expAttaked, Color color)
        {
            Board board = new Board();
            board[7, 7].PutNewFigure(5, Color.Black, 7, 7);
            board[7, 5].PutNewFigure(2, Color.Black, 7, 5);
            board[0, 0].PutNewFigure(4, Color.White, 0, 0);
            bool IsAttaked = board.IsSquareAttacked(x, y, color);
            Assert.AreEqual(IsAttaked, expAttaked);
        }

        [TestMethod()]
        [DataRow(0, 0, Color.Black)]
        [DataRow(0, 7, Color.Black)]
        [DataRow(7, 0, Color.White)]
        public void GetPlaceOfKingTest(int expX, int expY, Color color)
        {
            Board board = new Board();
            board[expX, expY].PutNewFigure(6, color, expX, expY);
            Assert.AreEqual(board.GetPlaceOfKing(color).x, expX);
            Assert.AreEqual(board.GetPlaceOfKing(color).y, expY);
        }

        [TestMethod()]
        public void CheckTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void МateTest()
        {
            Assert.Fail();
        }
    }
}