using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Bishop : Figure
    {
        public Bishop(Color color, int x, int y) : base(color, x, y)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            int x = this.x - 1;
            int y = this.y - 1;
            while (y >= 0 && x >= 0 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                y--;
                x--;
            }
            x = this.x + 1;
            y = this.y - 1;
            while (x < 8 && y >= 0 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                x++;
                y--;
            }
            x = this.x + 1;
            y = this.y + 1;
            while (x < 8 && y < 8 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                x++;
                y++;
            }
            x = this.x - 1;
            y = this.y + 1;
            while (x >= 0 && y < 8 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                x--;
                y++;
            }
            return AvailMoves;
        }

        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            int x = this.x - 1;
            int y = this.y - 1;
            while (y >= 0 && x >= 0 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                y--;
                x--;
            }
            x = this.x + 1;
            y = this.y - 1;
            while (x < 8 && y >= 0 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                x++;
                y--;
            }
            x = this.x + 1;
            y = this.y + 1;
            while (x < 8 && y < 8 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                x++;
                y++;
            }
            x = this.x - 1;
            y = this.y + 1;
            while (x >= 0 && y < 8 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                x--;
                y++;
            }
            return DefendedSquares;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Bishop: " + base.ToString();
        }
    }
}
