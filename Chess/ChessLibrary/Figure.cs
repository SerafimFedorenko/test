using System.Collections.Generic;

namespace ChessLibrary
{
    /// <summary>
    /// Enum that contains two types of color of figure
    /// </summary>
    public enum Color
    {
        /// <summary>
        /// White Color 
        /// </summary>
        White,
        /// <summary>
        /// Black Color
        /// </summary>
        Black
    }
    /// <summary>
    /// Class that realizes a figure
    /// </summary>
    public abstract class Figure
    {
        private int x;
        private int y;
        private Color color;
        /// <summary>
        /// Property that stores the number of row where the figure is located
        /// </summary>
        public int Y { get => y; set => y = value; }
        /// <summary>
        /// Property that stores the number of column where the figure is located
        /// </summary>
        public int X { get => x; set => x = value; }
        /// <summary>
        /// Property that stores the color of the figure
        /// </summary>
        public Color Color { get => color; set => color = value; }
        /// <summary>
        /// Constuctor of the class Figure that determine color and coordinates of the Figure
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Figure(Color color, int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }
        /// <summary>
        /// Figure copy constructor
        /// </summary>
        /// <param name="figure"></param>
        public Figure(Figure figure)
        {
            Color = figure.Color;
            X = figure.X;
            Y = figure.Y;
        }
        /// <summary>
        /// Method that realizes Move of figure
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        public void DoMove(Board board, int x, int y)
        {
            
            board[X, Y].ClearSquare();
            X = x;
            Y = y;
            board[x, y].PutFigure(this);
        }
        /// <summary>
        /// Method that finds out squares that figure can defend
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public abstract List<(int x, int y)> GetDefendedSquares(Board board);
        /// <summary>
        /// Method that finds out squares that figure can attack or move on those
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public abstract List<(int x, int y)> GetAvailableMoves(Board board);
        /// <summary>
        /// Method that finds out if figure can move in square
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool CanMove(Board board, int x, int y)
        {
            foreach ((int x, int y) point in GetAvailableMoves(board))
            {
                if (point.x == x && point.y == y)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Translate coordinates of figure to chess Notation
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private string Notation(int x)
        {
            string[] letters = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };
            return letters[x];
        }
        public override string ToString()
        {
            return "Color: " + Color + ", place: " + Notation(X) + (Y++);
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
            return X.GetHashCode() + Y.GetHashCode() + Color.GetHashCode();
        }
    }
}
