namespace ChessLibrary
{
    /// <summary>
    /// Class that realize a square of chess board
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Figure on this square
        /// </summary>
        public Figure figure;
        private bool empty;
        /// <summary>
        /// The property that answers the question: "The square is empty or contains a figure"
        /// </summary>
        public bool Empty { get => empty; set => empty = value; }
        /// <summary>
        /// Constructor of class Square
        /// </summary>
        public Square()
        {
            Empty = true;
            figure = null;
        }
        /// <summary>
        /// Method that clears the square
        /// </summary>
        public void ClearSquare()
        {
            Empty = true;
            figure = null;
        }
        /// <summary>
        /// Method that put аlready created figure on the square
        /// </summary>
        /// <param name="figure"></param>
        public void PutFigure(Figure figure)
        {
            Empty = false;
            this.figure = figure;
        }
        /// <summary>
        /// Method that creates figure and put it on the square
        /// </summary>
        /// <param name="TypeOfFigure"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PutNewFigure(int TypeOfFigure, Color color,int x, int y)
        {
            Empty = false;
            switch(TypeOfFigure)
            {
                case 1:
                    figure = new Pawn(color, x, y);
                    break;
                case 2:
                    figure = new Rock(color, x, y);
                    break;
                case 3:
                    figure = new Knight(color, x, y);
                    break;
                case 4:
                    figure = new Bishop(color, x, y);
                    break;
                case 5:
                    figure = new Queen(color, x, y);
                    break;
                case 6:
                    figure = new King(color, x, y);
                    break;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;

            Square square = (Square)obj;
            if (square.figure.Equals(figure) && square.Empty == Empty)
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
            return figure.GetHashCode() + empty.GetHashCode();
        }

        public override string ToString()
        {
            if (Empty)
            {
                return "Empty square";
            }
            else
            {
                return "Square: " + figure.ToString();
            }
        }
    }
}
