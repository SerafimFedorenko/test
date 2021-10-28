using System.Collections.Generic;

namespace ChessLibrary
{
    public class King : Figure
    {
        public King(Color color, int x, int y) : base(color, x, y)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            King king = (King)obj;
            if (king.Color == Color && king.X == X && king.Y == Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>()
            {
                (X - 1, Y - 1),(X, Y - 1),(X + 1, Y + 1),(X + 1, Y),(X + 1, Y - 1),(X, Y + 1),(X - 1, Y + 1),(X - 1, Y)
            };
            foreach ((int x, int y) point in AvailMoves)
            {
                if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7 || 
                    board.IsSquareDefended(point.x, point.y, Color) || board[point.x, point.y].figure.Color == Color)
                {
                    AvailMoves.Remove(point);
                }
            }
            return AvailMoves;
        }

        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>()
            {
                (X - 1, Y - 1),(X, Y - 1),(X + 1, Y + 1),(X + 1, Y),(X + 1, Y - 1),(X, Y + 1),(X - 1, Y + 1),(X - 1, Y)
            };
            foreach ((int x, int y) point in DefendedSquares)
            {
                if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7 || (!board[X, Y].empty && board[point.x, point.y].figure.Color != Color))
                {
                    DefendedSquares.Remove(point);
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
            return "King: " + base.ToString();
        }
    }
}
