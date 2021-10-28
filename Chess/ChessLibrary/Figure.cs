using System.Collections.Generic;

namespace ChessLibrary
{
    public enum Color
    {
        White,
        Black
    }
    public abstract class Figure
    {
        private int x;
        private int y;
        private Color color;

        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }
        public Color Color { get => color; set => color = value; }

        public Figure(Color color, int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }
        public Figure(Figure figure)
        {
            Color = figure.Color;
            X = figure.X;
            Y = figure.Y;
        }
        public void DoMove(int x, int y, Board board)
        {
            
            board[X, Y].ClearSquare();
            X = x;
            Y = y;
            board[x, y].PutFigure(this);
        }
        public abstract List<(int x, int y)> GetDefendedSquares(Board board);
        public abstract List<(int x, int y)> GetAvailableMoves(Board board);

        public override string ToString()
        {
            return "Color:" + Color + " place:" + Notation(X) + Y;
        }
        private string Notation(int x)
        {
            string[] letters = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };
            return letters[x];
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Figure figure = (Figure)obj;
            if (figure.Color == Color && figure.X == X && figure.Y == Y)
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
    }
}
