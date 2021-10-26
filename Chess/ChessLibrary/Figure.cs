using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public enum Color
    {
        White,
        Black
    }
    public abstract class Figure
    {
        public int x;
        public int y;
        public Color color;
        public Figure(Color color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }
        public Figure(Figure figure)
        {
            color = figure.color;
            x = figure.x;
            y = figure.y;
        }
        public void DoMove(int x, int y, Board board)
        {
            board[x, y].figure = this;
            board[this.x, this.y].ClearSquare();
            this.x = x;
            this.y = y;
        }
        public bool IsDefended(Board board)
        {
            bool defended = false;
            foreach ((int x, int y) point in board.GetAllDefendedSquares(color))
            {
                if (point == (x, y))
                {
                    defended = true;
                    break;
                }
            }
            return defended;
        }
        public bool IsAttacked(Board board)
        {
            bool defended = false;
            foreach ((int x, int y) point in board.GetAllAttackedSquares(color))
            {
                if (point == (x, y))
                {
                    defended = true;
                    break;
                }
            }
            return defended;
        }
        public abstract List<(int x, int y)> GetDefendedSquares(Board board);
        public abstract List<(int x, int y)> GetAvailableMoves(Board board);

        public override string ToString()
        {
            return "Color:" + color + " place:" + Notation(x) + y;
        }
        private string Notation(int x)
        {
            string[] letters = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };
            return letters[x];
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
