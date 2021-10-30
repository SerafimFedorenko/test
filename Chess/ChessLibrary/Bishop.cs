using System.Collections.Generic;

namespace ChessLibrary
{
    /// <summary>
    /// Class that realizes figure bishop
    /// </summary>
    public class Bishop : Figure
    {
        /// <summary>
        /// Constuctor of the class Bishop that determine color and coordinates of the Bishop
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Bishop(Color color, int x, int y) : base(color, x, y)
        {
        }
        /// Copy constructor that сreates a bishop from a pawn
        /// </summary>
        /// <param name="pawn"></param>
        public Bishop(Pawn pawn) : base(pawn)
        {
        }
        /// <summary>
        /// Method that finds out squares that bishop can attack or move on those
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            int x = X - 1;
            int y = Y - 1;
            while (y >= 0 && x >= 0 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                y--;
                x--;
            }
            x = X + 1;
            y = Y - 1;
            while (x < 8 && y >= 0 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                x++;
                y--;
            }
            x = X + 1;
            y = Y + 1;
            while (x < 8 && y < 8 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                x++;
                y++;
            }
            x = X - 1;
            y = Y + 1;
            while (x >= 0 && y < 8 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                x--;
                y++;
            }
            return AvailMoves;
        }
        /// <summary>
        /// Method that finds out squares that bishop can defend
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>

        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            int x = X - 1;
            int y = Y - 1;
            while (y >= 0 && x >= 0 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                y--;
                x--;
            }
            x = X + 1;
            y = Y - 1;
            while (x < 8 && y >= 0 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                x++;
                y--;
            }
            x = X + 1;
            y = Y + 1;
            while (x < 8 && y < 8 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                x++;
                y++;
            }
            x = X - 1;
            y = Y + 1;
            while (x >= 0 && y < 8 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                x--;
                y++;
            }
            return DefendedSquares;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Color.GetHashCode();
        }

        public override string ToString()
        {
            return "Bishop: " + base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Bishop bishop = (Bishop)obj;
            if (bishop.Color == Color && bishop.X == X && bishop.Y == Y)
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
