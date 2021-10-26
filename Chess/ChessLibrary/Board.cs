using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Board
    {
        private Square[,] board = new Square[8, 8];
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
        public List<(int x, int y)> GetAllDefendedSquares(Color color)
        {
            List<(int x, int y)> AllDefendedSquares = new List<(int x, int y)>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(!board[x, y].empty && board[x, y].figure.color == color)
                    {
                        AllDefendedSquares.AddRange(board[x, y].figure.GetDefendedSquares(this));
                    }
                }
            }
            return AllDefendedSquares;
        }
        public List<(int x, int y)> GetAllAttackedSquares(Color color)
        {
            List<(int x, int y)> AllDefendedSquares = new List<(int x, int y)>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (!board[x, y].empty && board[x, y].figure.color == color)
                    {
                        AllDefendedSquares.AddRange(board[x, y].figure.GetAvailableMoves(this));
                    }
                }
            }
            return AllDefendedSquares;
        }
    }
}
