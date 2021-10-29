using System.Collections.Generic;

namespace ChessLibrary
{
    /// <summary>
    /// Class that realizes figure knight
    /// </summary>
    public class Pawn : Figure
    {
        /// <summary>
        /// Constuctor of the class Pawn that determine color and coordinates of the Pawn
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Pawn(Color color, int x, int y) : base(color, x, y)
        {
        }
        /// <summary>
        /// Method that finds out squares that pawn can attack or move on those
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            if (Color == Color.Black)
            {
                if (board[X, Y - 1].Empty)
                {
                    AvailMoves.Add((X, Y - 1));
                }
                if (Y == 6 && board[X, Y - 2].Empty)
                {
                    AvailMoves.Add((X, Y - 2));
                }
                if (X != 0 && !board[X - 1, Y - 1].Empty && board[X - 1, Y - 1].figure.Color != Color)
                {
                    AvailMoves.Add((X - 1, Y - 1));
                }
                if (X != 7 && !board[X + 1, Y - 1].Empty && board[X + 1, Y - 1].figure.Color != Color)
                {
                    AvailMoves.Add((X + 1, Y - 1));
                }
            }
            else
            {
                if (board[X, Y + 1].Empty)
                {
                    AvailMoves.Add((X, Y + 1));
                }
                if (Y == 1 && board[X, Y + 2].Empty)
                {
                    AvailMoves.Add((X, Y + 2));
                }
                if (X != 7 && !board[X + 1, Y + 1].Empty && board[X + 1, Y + 1].figure.Color != Color)
                {
                    AvailMoves.Add((X + 1, Y + 1));
                }
                if (X != 0 && !board[X - 1, Y + 1].Empty && board[X - 1, Y + 1].figure.Color != Color)
                {
                    AvailMoves.Add((X - 1, Y + 1));
                }
            }
            return AvailMoves;
        }
        /// <summary>
        /// Method that finds out squares that pawn can defend
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            if (Color == Color.Black)
            {
                if (X != 0 && !board[X - 1, Y - 1].Empty && board[X - 1, Y - 1].figure.Color == Color)
                {
                    DefendedSquares.Add((X - 1, Y - 1));
                }
                if (X != 7 && !board[X + 1, Y - 1].Empty && board[X + 1, Y - 1].figure.Color == Color)
                {
                    DefendedSquares.Add((X + 1, Y - 1));
                }
            }
            else
            {
                if (X != 7 && !board[X + 1, Y + 1].Empty && board[X + 1, Y + 1].figure.Color == Color)
                {
                    DefendedSquares.Add((X + 1, Y + 1));
                }
                if (X != 0 && !board[X - 1, Y + 1].Empty && board[X - 1, Y + 1].figure.Color == Color)
                {
                    DefendedSquares.Add((X - 1, Y + 1));
                }
            }
            return DefendedSquares;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Pawn: " + base.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Pawn pawn = (Pawn)obj;
            if (pawn.Color == Color && pawn.X == X && pawn.Y == Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
