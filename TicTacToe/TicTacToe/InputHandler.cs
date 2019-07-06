using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    class InputHandler {
        public ICommand HandleInput(char userInput) {
            int playerIndex = Convert.ToInt32(Board.Singleton.CurrentPlayer) - 1;
            if (userInput == KeyBinds.Keys[playerIndex, 0])     return new MarkCommand(0);
            if (userInput == KeyBinds.Keys[playerIndex, 1])     return new MarkCommand(1);
            if (userInput == KeyBinds.Keys[playerIndex, 2])     return new MarkCommand(2);
            if (userInput == KeyBinds.Keys[playerIndex, 3])     return new MarkCommand(3);
            if (userInput == KeyBinds.Keys[playerIndex, 4])     return new MarkCommand(4);
            if (userInput == KeyBinds.Keys[playerIndex, 5])     return new MarkCommand(5);
            if (userInput == KeyBinds.Keys[playerIndex, 6])     return new MarkCommand(6);
            if (userInput == KeyBinds.Keys[playerIndex, 7])     return new MarkCommand(7);
            if (userInput == KeyBinds.Keys[playerIndex, 8])     return new MarkCommand(8);
            if (userInput == 'n')                               return new UndoCommand();
            if (userInput == 'm')                               return new RedoCommand();
            return null;
        }
    }
}
