using System.Collections.Generic;
using System.Linq;

namespace ChessLibrary
{
    /// <summary>
    /// Class that realize chess board
    /// </summary>
    public class Board
    {
        private Square[,] board = new Square[8, 8];
        /// <summary>
        /// Method that create empty chess board
        /// </summary>
        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = new Square();
                }
            }
        }
        /// <summary>
        /// Indexer of class Board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Square this[int x, int y]
        {
            get
            {
                return board[x, y];
            }
            set
            {
                board[x, y] = value;
            }
        }
        /// <summary>
        /// Method that finds out is square is defended by figures with entered color
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool IsSquareDefended(int x, int y, Color color)
        {
            foreach ((int x, int y) point in GetAllDefendedSquares(color))
            {
                if (point.x == x && point.y == y)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Method that finds out is square is attacked by figures with entered color
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool IsSquareAttacked(int x, int y, Color color)
        {
            foreach ((int x, int y) point in GetAllAttackedSquares(color))
            {
                if (point.x == x && point.y == y)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Method that realize start placement of figures
        /// </summary>
        public void StartPlacement()
        {
            for (int i = 0; i < 8; i++)
            {
                board[i, 1].PutNewFigure(1, Color.White, i, 1);
                board[i, 6].PutNewFigure(1, Color.Black, i, 6);
            }

            board[0, 0].PutNewFigure(2, Color.White, 0, 0);
            board[7, 0].PutNewFigure(2, Color.White, 7, 0);
            board[0, 7].PutNewFigure(2, Color.Black, 0, 7);
            board[7, 7].PutNewFigure(2, Color.Black, 7, 7);

            board[1, 0].PutNewFigure(3, Color.White, 1, 0);
            board[6, 0].PutNewFigure(3, Color.White, 6, 0);
            board[1, 7].PutNewFigure(3, Color.Black, 1, 7);
            board[6, 7].PutNewFigure(3, Color.Black, 6, 7);

            board[2, 0].PutNewFigure(4, Color.White, 2, 0);
            board[5, 0].PutNewFigure(4, Color.White, 5, 0);
            board[2, 7].PutNewFigure(4, Color.Black, 2, 7);
            board[5, 7].PutNewFigure(4, Color.Black, 5, 7);

            board[3, 0].PutNewFigure(5, Color.White, 3, 0);
            board[3, 7].PutNewFigure(5, Color.Black, 3, 7);

            board[4, 0].PutNewFigure(6, Color.White, 4, 0);
            board[4, 7].PutNewFigure(6, Color.Black, 4, 7);
        }
        /// <summary>
        /// Method that return all deffended squares by figures with entered color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private List<(int x, int y)> GetAllDefendedSquares(Color color)
        {
            List<(int x, int y)> AllDefendedSquares = new List<(int x, int y)>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(!board[x, y].Empty && board[x, y].figure.Color == color)
                    {
                        AllDefendedSquares.AddRange(board[x, y].figure.GetDefendedSquares(this));
                    }
                }
            }
            return AllDefendedSquares;
        }
        /// <summary>
        /// Method that return all attacked squares by figures with entered color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private List<(int x, int y)> GetAllAttackedSquares(Color color)
        {
            List<(int x, int y)> AllDefendedSquares = new List<(int x, int y)>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (!board[x, y].Empty && board[x, y].figure.Color == color)
                    {
                        AllDefendedSquares.AddRange(board[x, y].figure.GetAvailableMoves(this));
                    }
                }
            }
            return AllDefendedSquares;
        }
        /// <summary>
        /// Method that finds out the place off the king with entered color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public (int x, int y) GetPlaceOfKing(Color color)
        {
            King king = new King(color,0, 0);
            (int x, int y) PlaceOfKing = (-1, -1);
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    king.X = x;
                    king.Y = y;
                    if (!board[x, y].Empty && king.Equals(board[x, y].figure))
                    {
                        PlaceOfKing = (x, y);
                    }
                }
            }
            return PlaceOfKing;
        }
        /// <summary>
        /// Method that finds out is place of king is attacked by figures with entered color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool Check(Color color)
        {
            if (color == Color.Black)
            {
                (int x, int y) PlaceOfKing = GetPlaceOfKing(Color.Black);
                return IsSquareAttacked(PlaceOfKing.x, PlaceOfKing.y, Color.White);
            }
            else
            {
                (int x, int y) PlaceOfKing = GetPlaceOfKing(Color.White);
                return IsSquareAttacked(PlaceOfKing.x, PlaceOfKing.y, Color.Black);
            }
        }
        /// <summary>
        /// Method that return lest of all figures with entered color on the board
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private List<Figure> GetListOfFigures(Color color)
        {
            List<Figure> ListOfFigures = new List<Figure>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (!board[x, y].Empty && board[x, y].figure.Color == color)
                    {
                        ListOfFigures.Add(board[x, y].figure);
                    }
                }
            }
            return ListOfFigures;
        }
        /// <summary>
        /// Method that find out is king is attacked and can king to move
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool Мate(Color color)
        {
            if (color == Color.Black)
            {
                (int x, int y) PlaceOfKing = GetPlaceOfKing(Color.Black);
                if (Check(Color.Black) && board[PlaceOfKing.x, PlaceOfKing.y].figure.GetAvailableMoves(this).Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                (int x, int y) PlaceOfKing = GetPlaceOfKing(Color.White);
                if (Check(Color.White))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Method that create list of figures in the board
        /// </summary>
        /// <returns></returns>
        private string GetStringListOfFigures()
        {
            string stringListOfFigures = "";
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (!board[x, y].Empty)
                    {
                        stringListOfFigures += "\n" + board[x, y].figure.ToString() + ";";
                    }
                }
            }
            return stringListOfFigures;
        }
        public override string ToString()
        {
            return "List of Figures: " + GetStringListOfFigures();
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
