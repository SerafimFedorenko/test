using System.Collections.Generic;

namespace ChessLibrary
{
    /// <summary>
    /// Class that realizes figure knight
    /// </summary>
    public class Knight : Figure
    {
        /// <summary>
        /// Constuctor of the class Knight that determine color and coordinates of the Knight
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Knight(Color color, int x, int y) : base(color, x, y)
        {
        }
        /// <summary>
        /// Copy constructor that сreates a knight from a pawn
        /// </summary>
        /// <param name="pawn"></param>
        public Knight(Pawn pawn) : base(pawn)
        {
        }

        /// <summary>
        /// Method that finds out squares that knight can attack or move on those
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> DefaultAvailMoves = new List<(int x, int y)>()
            {
                (X - 2, Y - 1),(X - 1, Y - 2),(X + 1, Y - 2),(X + 2, Y - 1),(X + 1, Y + 2),(X + 2, Y + 1),(X - 1, Y + 2),(X - 2, Y + 1)
            };
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            foreach ((int x, int y) point in DefaultAvailMoves)
            {
                if (point.x >= 0 && point.x < 8& point.y >= 0 && point.y < 8 && (board[point.x, point.y].Empty || board[point.x, point.y].figure.Color != Color))
                {
                    AvailMoves.Add(point);
                }
            }
            return AvailMoves;
        }
        /// <summary>
        /// Method that finds out squares that knight can defend
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefaultDefendedSquares = new List<(int x, int y)>()
            {
                (X - 2, Y - 1),(X - 1, Y - 2),(X + 1, Y - 2),(X + 2, Y - 1),(X + 1, Y + 2),(X + 2, Y + 1),(X - 1, Y + 2),(X - 2, Y + 1)
            };
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            foreach ((int x, int y) point in DefaultDefendedSquares)
            {
                if (point.x >= 0 && point.x < 8 & point.y >= 0 && point.y < 8 && (board[point.x, point.y].Empty || board[point.x, point.y].figure.Color == Color))
                {
                    DefendedSquares.Add(point);
                }
            }
            return DefendedSquares;
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
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Color.GetHashCode();
        }

        public override string ToString()
        {
            return "Knight:" + base.ToString();
        }
    }
}
