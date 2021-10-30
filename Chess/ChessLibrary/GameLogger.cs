using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLibrary;

namespace ChessLibrary
{
    /// <summary>
    /// Class that recording moves in game
    /// </summary>
    class GameLogger
    {
        private ILogger _logger;
        /// <summary>
        /// Constructor of GameLogger
        /// </summary>
        public GameLogger()
        {
            _logger = new TXTLogger("Chess");
        }
        /// <summary>
        /// Method that recording move in text file 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void WriteMove(Color color, int x1, int y1, int x2, int y2)
        {
            string[] letters = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };
            string text = color + ":" + letters[x1] + (y1 + 1) + "-" + letters[x2] + (y2 + 1);
            _logger.Write(text);
        }
        
    }
}
