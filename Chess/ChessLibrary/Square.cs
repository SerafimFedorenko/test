using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Square
    {
        public Figure figure = null;
        public bool empty = true;
        public void ClearSquare()
        {
            empty = true;
            figure = null;
        }
    }
}
