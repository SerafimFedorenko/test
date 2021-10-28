using System.Collections.Generic;

namespace ChessLibrary
{
    public class Knight : Figure
    {
        public Knight(Color color, int x, int y) : base(color, x, y)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Knight knight = (Knight)obj;
            if (knight.Color == Color && knight.X == X && knight.Y == Y)
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
            List<(int x, int y)> DefaultAvailMoves = new List<(int x, int y)>()
            {
                (X - 2, Y - 1),(X - 1, Y - 2),(X + 1, Y - 2),(X + 2, Y - 1),(X + 1, Y + 2),(X + 2, Y + 1),(X - 1, Y + 2),(X - 2, Y + 1)
            };
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            foreach ((int x, int y) point in DefaultAvailMoves)
            {
                if (point.x >= 0 && point.x < 8& point.y >= 0 && point.y < 8 && (board[point.x, point.y].empty || board[point.x, point.y].figure.Color != Color))
                {
                    AvailMoves.Add(point);
                }
            }
            return AvailMoves;
        }

        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>()
            {
                (X - 2, Y - 1),(X - 1, Y - 2),(X + 1, Y - 2),(X + 2, Y - 1),(X + 1, Y + 2),(X + 2, Y + 1),(X - 1, Y + 2),(X - 2, Y + 1)
            };
            foreach ((int x, int y) point in DefendedSquares)
            {
                if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7 || board[point.x, point.y].figure.Color != Color)
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
            return "Knight:" + base.ToString();
        }
    }
}
