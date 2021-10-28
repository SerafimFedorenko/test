namespace ChessLibrary
{
    public class Square
    {
        public Figure figure;
        public bool empty;
        public Square()
        {
            figure = null;
            empty = true;
        }
        public void ClearSquare()
        {
            empty = true;
            figure = null;
        }
        public void PutFigure(Figure figure)
        {
            empty = false;
            this.figure = figure;
        }
        public void PutNewFigure(int TypeOfFigure, Color color,int x, int y)
        {
            empty = false;
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
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            if (empty)
            {
                return "Empty square";
            }
            else
            {
                return "Square include fugure:" + figure.ToString();
            }
        }
    }
}
