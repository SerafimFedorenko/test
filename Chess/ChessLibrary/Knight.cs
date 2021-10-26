using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Knight : Figure
    {
        public Knight(Color color, int x, int y) : base(color, x, y)
        {
        }

        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>()
            {
                (x - 2, y - 1),(x - 1, y - 2),(x + 1, y - 2),(x + 2, y - 1),(x + 1, y + 2),(x + 2, y + 1),(x - 1, y + 2),(x - 2, y + 1)
            };
            foreach ((int x, int y) point in AvailMoves)
            {
                if (point.x < 0 || point.x > 7|| point.y < 0 || point.y > 7 || board[x, y].figure.color == color)
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
                (x - 2, y - 1),(x - 1, y - 2),(x + 1, y - 2),(x + 2, y - 1),(x + 1, y + 2),(x + 2, y + 1),(x - 1, y + 2),(x - 2, y + 1)
            };
            foreach ((int x, int y) point in DefendedSquares)
            {
                if (point.x < 0 || point.x > 7 || point.y < 0 || point.y > 7 || board[x, y].figure.color != color)
                {
                    DefendedSquares.Remove(point);
                }
            }
            return DefendedSquares;
        }
    }
}
