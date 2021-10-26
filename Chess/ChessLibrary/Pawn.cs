using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Pawn : Figure
    {
        public Pawn(Color color, int x, int y) : base(color, x, y)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            if (color == Color.White)
            {
                if (board[x, y - 1].empty)
                {
                    AvailMoves.Add((x, y - 1));
                }
                if (y == 6 && board[x, y - 2].empty)
                {
                    AvailMoves.Add((x, y - 2));
                }
                if (x != 0 && board[x - 1, y - 1].figure.color != color)
                {
                    AvailMoves.Add((x - 1, y - 1));
                }
                if (x != 7 && board[x + 1, y - 1].figure.color != color)
                {
                    AvailMoves.Add((x + 1, y - 1));
                }
            }
            else
            {
                if (board[x, y + 1].empty)
                {
                    AvailMoves.Add((x, y + 1));
                }
                if (y == 1 && board[x, y + 2].empty)
                {
                    AvailMoves.Add((x, y + 2));
                }
                if (x != 7 && board[x + 1, y + 1].figure.color != color)
                {
                    AvailMoves.Add((x + 1, y + 1));
                }
                if (x != 0 && board[x - 1, y + 1].figure.color != color)
                {
                    AvailMoves.Add((x - 1, y + 1));
                }
            }
            return AvailMoves;
        }

        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            if (color == Color.White)
            {
                if (x != 0 && board[x - 1, y - 1].figure.color == color)
                {
                    DefendedSquares.Add((x - 1, y - 1));
                }
                if (x != 7 && board[x + 1, y - 1].figure.color == color)
                {
                    DefendedSquares.Add((x + 1, y - 1));
                }
            }
            else
            {
                if (x != 7 && board[x + 1, y + 1].figure.color == color)
                {
                    DefendedSquares.Add((x + 1, y + 1));
                }
                if (x != 0 && board[x - 1, y + 1].figure.color == color)
                {
                    DefendedSquares.Add((x - 1, y + 1));
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
    }
}
