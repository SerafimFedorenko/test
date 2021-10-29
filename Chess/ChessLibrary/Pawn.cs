using System.Collections.Generic;

namespace ChessLibrary
{
    public class Pawn : Figure
    {
        public Pawn(Color color, int x, int y) : base(color, x, y)
        {
        }

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
