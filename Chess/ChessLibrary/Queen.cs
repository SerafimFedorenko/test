using System.Collections.Generic;

namespace ChessLibrary
{
    public class Queen : Figure
    {
        public Queen(Color color, int x, int y) : base(color, x, y)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Queen queen = (Queen)obj;
            if (queen.Color == Color && queen.X == X && queen.Y == Y)
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
            List<(int x, int y)> AvailMoves = new List<(int x, int y)>();
            Bishop bishop = new Bishop(Color, X, Y);
            Rock rock = new Rock(Color, X, Y);
            AvailMoves.AddRange(bishop.GetAvailableMoves(board));
            AvailMoves.AddRange(rock.GetAvailableMoves(board));
            return AvailMoves;
        }
        public override List<(int x, int y)> GetDefendedSquares(Board board)
        {
            List<(int x, int y)> DefendedSquares = new List<(int x, int y)>();
            Bishop bishop = new Bishop(Color, X, Y);
            Rock rock = new Rock(Color, X, Y);
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
