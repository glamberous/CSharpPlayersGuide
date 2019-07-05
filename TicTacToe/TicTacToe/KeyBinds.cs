using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    struct KeyBinds {
        static public char[,] Keys = new char[,] {
            {  'q', 'w', 'e', 'a', 's', 'd', 'z', 'x', 'c', },
            {  '7', '8', '9', '4', '5', '6', '1', '2', '3', },
        };
    }

    public enum Players { None, X, O }
}
