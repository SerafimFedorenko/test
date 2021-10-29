using System.Collections.Generic;

namespace ChessLibrary
{
    public class Rock : Figure
    {
        public Rock(Color color, int x, int y) : base(color, x, y)
        {
        }

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
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Rock:" + base.ToString();
        }
    }
}
