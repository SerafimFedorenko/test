using System.Collections.Generic;

namespace ChessLibrary
{
    /// <summary>
    /// Class that realizes figure queen
    /// </summary>
    public class Rock : Figure
    {
        /// <summary>
        /// Constuctor of the class Rock that determine color and coordinates of the Rock
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Rock(Color color, int x, int y) : base(color, x, y)
        {
        }
        /// Copy constructor that сreates a rock from a pawn
        /// </summary>
        /// <param name="pawn"></param>
        public Rock(Pawn pawn) : base(pawn)
        {
        }
        /// <summary>
        /// Method that finds out squares that rock can attack or move on those
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            int x = X;
            int y = Y - 1;
            while (y >= 0 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                y--;
            }
            x = X + 1;
            y = Y;
            while (x < 8 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                x++;
            }
            x = X;
            y = Y + 1;
            while (y < 8 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                y++;
            }
            x = X - 1;
            y = Y;
            while (x >= 0 && (board[x, y].Empty || board[x, y].figure.Color != Color))
            {
                AvailMoves.Add((x, y));
                if (!board[x, y].Empty) break;
                x--;
            }
            return AvailMoves;
        }
        /// <summary>
        /// Method that finds out squares that rock can defend
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            int x = X;
            int y = Y - 1;
            while (y >= 0 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                y--;
            }
            x = X + 1;
            y = Y;
            while (x < 8 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                x++;
            }
            x = X;
            y = Y + 1;
            while (y < 8 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                y++;
            }
            x = X - 1;
            y = Y;
            while (x >= 0 && (board[x, y].Empty || board[x, y].figure.Color == Color))
            {
                DefendedSquares.Add((x, y));
                if (!board[x, y].Empty) break;
                x--;
            }
            return DefendedSquares;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Rock rock = (Rock)obj;
            if (rock.Color == Color && rock.X == X && rock.Y == Y)
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
            return "Rock:" + base.ToString();
        }
    }
}
