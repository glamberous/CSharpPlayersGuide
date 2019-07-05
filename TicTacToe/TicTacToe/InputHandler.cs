using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    class InputHandler {
        public ICommand HandleInput(char userInput, Players currentPlayer) {
            int keyIndex = Convert.ToInt32(currentPlayer) - 1;
            if (userInput == KeyBinds.Keys[keyIndex, 0])     return new MarkCommand(0, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 1])     return new MarkCommand(1, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 2])     return new MarkCommand(2, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 3])     return new MarkCommand(3, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 4])     return new MarkCommand(4, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 5])     return new MarkCommand(5, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 6])     return new MarkCommand(6, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 7])     return new MarkCommand(7, currentPlayer);
            if (userInput == KeyBinds.Keys[keyIndex, 8])     return new MarkCommand(8, currentPlayer);
            //case 'n': return undo
            //case 'm': return redo
            return null;
        }
    }
}
