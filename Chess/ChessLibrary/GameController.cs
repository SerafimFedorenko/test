using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLibrary;

namespace ChessLibrary
{
    /// <summary>
    /// Class that realizes game of chess 
    /// </summary>
    public class GameController
    {
        private GameLogger _logger;
        /// <summary>
        /// Field that means which player can move
        /// </summary>
        public Color colorOfPlayer;
        /// <summary>
        /// The board players play on
        /// </summary>
        public Board board;
        /// <summary>
        /// Constructor of the class GameController
        /// </summary>
        public GameController()
        {
            _logger = new GameLogger();
            colorOfPlayer = Color.White;
            board = new Board(); 
            board.StartPlacement();
        }
        /// <summary>
        /// Method that changes color off player
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Color ChangeColor(Color color)
        {
            if (color == Color.Black)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }
        /// <summary>
        /// Method that realize moves of players
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void TurnToMove(int x1, int y1, int x2, int y2)
        {
            if (!board[x1, y1].Empty && board[x1, y1].figure.Color == colorOfPlayer && board[x1, y1].figure.CanMove(board, x2, y2))
            {
                board[x1, y1].figure.DoMove(board, x2, y2);
                _logger.WriteMove(colorOfPlayer, x1, y1, x2, y2);
                colorOfPlayer = ChangeColor(colorOfPlayer);
            }
        }

        public override string ToString()
        {
            return "Game: " + "Color of player:" + colorOfPlayer + ";\n" + board.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            else
            {
                GameController game = (GameController)obj;
                if (game.board.Equals(board) && game.colorOfPlayer == colorOfPlayer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override int GetHashCode()
        {
            return _logger.GetHashCode() + colorOfPlayer.GetHashCode() + board.GetHashCode();
        }
    }
}
