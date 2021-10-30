using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessLibrary.Tests
{
    [TestClass()]
    public class PawnTests
    {
        [DataTestMethod()]
        [DataRow(0, 1, 0, 2, 0, 3)]
        [DataRow(1, 1, 1, 2, 1, 3)]
        [DataRow(7, 1, 7, 2, 7, 3)]
        [DataRow(0, 6, 0, 5, 0, 4)]
        [DataRow(7, 6, 7, 5, 7, 4)]
        public void GetAvailableMovesTest1(params int[] places)
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
        [DataTestMethod()]
        [DataRow(3, 4, 3, 5, 4, 5, 2, 5)]
        [DataRow(3, 1, 3, 2, 3, 3)]
        [DataRow(0, 2, 0, 3)]
        [DataRow(7, 1, 7, 2)]
        [DataRow(6, 1, 6, 2)]
        public void GetAvailableMovesTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(1, Color.White, places[0], places[1]);
            board[4, 5].PutNewFigure(3, Color.Black, 4, 5);
            board[2, 5].PutNewFigure(3, Color.Black, 2, 5);
            board[7, 3].PutNewFigure(3, Color.Black, 7, 3);
            board[6, 3].PutNewFigure(3, Color.White, 6, 3);
            int i = 2;
            foreach ((int x, int y) in board[places[0], places[1]].figure.GetAvailableMoves(board))
            {
                Assert.AreEqual(places[i], x);
                Assert.AreEqual(places[i + 1], y);
                i += 2;
            }
        }
        [DataTestMethod()]
        [DataRow(3, 4, 4, 5, 2, 5)]
        [DataRow(1, 1, 2, 2)]
        [DataRow(0, 1, 1, 2)]
        public void GetDefendedSquaresTest(params int[] places)
        {
            Board board = new Board();
            board[places[0], places[1]].PutNewFigure(1, Color.White, places[0], places[1]);
            board[4, 5].PutNewFigure(3, Color.White, 4, 5);
            board[2, 5].PutNewFigure(3, Color.White, 2, 5);
            board[0, 2].PutNewFigure(3, Color.Black, 0, 2);
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