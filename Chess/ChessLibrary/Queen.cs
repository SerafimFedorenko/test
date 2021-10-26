using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Queen : Figure
    {
        public Queen(Color color, int x, int y) : base(color, x, y)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override List<(int x, int y)> GetAvailableMoves(Board board)
        {
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            Bishop bishop = new Bishop(color, x, y);
            Rock rock = new Rock(color, x, y);
            AvailMoves.AddRange(bishop.GetAvailableMoves(board));
            AvailMoves.AddRange(rock.GetAvailableMoves(board));
            return AvailMoves;
        }
        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            Bishop bishop = new Bishop(color, x, y);
            Rock rock = new Rock(color, x, y);
            DefendedSquares.AddRange(bishop.GetDefendedSquares(board));
            DefendedSquares.AddRange(rock.GetDefendedSquares(board));
            return DefendedSquares;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Queen:" + base.ToString();
        }
    }
}
