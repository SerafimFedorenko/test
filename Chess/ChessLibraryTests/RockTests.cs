using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    [TestClass()]
    public class RockTests
    {

        [DataTestMethod()]
        [DataRow(0, 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7)]
        [DataRow(1, 1, 1, 0, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 0, 1)]
        [DataRow(4, 4, 4, 3, 5, 4, 4, 5, 3, 4, 2, 4)]
        public void GetAvailableMovesTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(2, Color.Black, places[0], places[1]);
            board[4, 6].PutNewFigure(3, Color.Black, 4, 6);
            board[6, 4].PutNewFigure(4, Color.Black, 6, 4);
            board[2, 4].PutNewFigure(5, Color.White, 2, 4);
            board[4, 2].PutNewFigure(1, Color.Black, 4, 2);
            int i = 2;
            foreach ((int x, int y) in board[places[0], places[1]].figure.GetAvailableMoves(board))
            {
                Assert.AreEqual(places[i], x);
                Assert.AreEqual(places[i + 1], y);
                i += 2;
            }
        }
        [DataTestMethod()]
        [DataRow(0, 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7)]
        [DataRow(1, 1, 1, 0, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 0, 1)]
        [DataRow(4, 4, 4, 3, 5, 4, 4, 5, 3, 4, 2, 4)]
        public void GetDefendedSquaresTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(2, Color.Black, places[0], places[1]);
            board[4, 6].PutNewFigure(3, Color.White, 4, 6);
            board[6, 4].PutNewFigure(4, Color.White, 6, 4);
            board[2, 4].PutNewFigure(5, Color.Black, 2, 4);
            board[4, 2].PutNewFigure(1, Color.White, 4, 2);
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