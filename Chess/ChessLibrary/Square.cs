namespace ChessLibrary
{
    public class Square
    {
        public Figure figure;
        private bool empty;

        public bool Empty { get => empty; set => empty = value; }

        public Square()
        {
            Empty = true;
            figure = null;
        }
        public void ClearSquare()
        {
            Empty = true;
            figure = null;
        }
        public void PutFigure(Figure figure)
        {
            Empty = false;
            this.figure = figure;
        }
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
            return base.GetHashCode();
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
