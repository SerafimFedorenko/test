using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    [TestClass()]
    public class KnightTests
    {
        [DataTestMethod()]
        //(X - 2, Y - 1),(X - 1, Y - 2),(X + 1, Y - 2),(X + 2, Y - 1),(X + 1, Y + 2),(X + 2, Y + 1),(X - 1, Y + 2),(X - 2, Y + 1)
        [DataRow(1, 0, 2, 2, 0, 2)]
        [DataRow(3, 3, 1, 2, 2, 1, 4, 1, 5, 2, 4, 5, 5, 4, 2, 5)]
        public void GetAvailableMovesTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(3, Color.Black, places[0], places[1]);
            board[3, 1].PutNewFigure(1, Color.Black, 3, 1);
            board[1, 4].PutNewFigure(1, Color.Black, 1, 4);
            board[2, 5].PutNewFigure(1, Color.White, 2, 5);
            int i = 2;
            foreach ((int x, int y) in board[places[0], places[1]].figure.GetAvailableMoves(board))
            {
                Assert.AreEqual(places[i], x);
                Assert.AreEqual(places[i + 1], y);
                i += 2;
            }
        }

        [DataTestMethod()]
        [DataRow(1, 0, 2, 2, 3, 1, 0, 2)]
        [DataRow(3, 3, 1, 2, 2, 1, 4, 1, 5, 2, 4, 5, 5, 4, 1, 4)]
        public void GetDefendedSquaresTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(3, Color.Black, places[0], places[1]);
            board[3, 1].PutNewFigure(1, Color.Black, 3, 1);
            board[1, 4].PutNewFigure(1, Color.Black, 1, 4);
            board[2, 5].PutNewFigure(1, Color.White, 2, 5);
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