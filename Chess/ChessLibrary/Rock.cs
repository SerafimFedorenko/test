using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int x = this.x;
            int y = this.y - 1;
            while (y >= 0 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                y--;
            }
            x = this.x + 1;
            y = this.y;
            while (x < 8 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                y--;
            }
            x = this.x;
            y = this.y + 1;
            while (y < 8 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                y++;
            }
            x = this.x - 1;
            y = this.y;
            while (x >= 0 && (board[x, y].empty || board[x, y].figure.color != color))
            {
                AvailMoves.Add((x, y));
                if (board[x, y].figure != null) break;
                x--;
            }
            return AvailMoves;
        }

        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            int x = this.x;
            int y = this.y - 1;
            while (y >= 0 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                y--;
            }
            x = this.x + 1;
            y = this.y;
            while (x < 8 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                y--;
            }
            x = this.x;
            y = this.y + 1;
            while (y < 8 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                y++;
            }
            x = this.x - 1;
            y = this.y;
            while (x >= 0 && (board[x, y].empty || board[x, y].figure.color == color))
            {
                DefendedSquares.Add((x, y));
                if (board[x, y].figure != null) break;
                x--;
            }
            return DefendedSquares;
        }
    }
}
