using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    class CommandInvoker {
        private readonly ICommand[] commands;
        public CommandInvoker() => commands = new ICommand[10];
        
        private int commandIndex = 0;
        private void IncrementIndex() => commandIndex = commandIndex != 9 ? commandIndex + 1 : 0;
        private void DecrementIndex() => commandIndex = commandIndex != 0 ? commandIndex - 1 : 9;

        public void SetCommand(ICommand command) => commands[commandIndex] = command;

        public void Invoke() {
            commands[commandIndex].ExecuteAction();
            IncrementIndex();
            commands[commandIndex] = null;
        }

        public void Undo() {
            DecrementIndex();
            if (commands[commandIndex] != null) {
                commands[commandIndex].UndoAction();
                Console.WriteLine("\nAction Undone.");
            } else {
                IncrementIndex();
            }
        }

        public void Redo() {
            if (commands[commandIndex] != null) {
                commands[commandIndex].ExecuteAction();
                IncrementIndex();
                Console.WriteLine("\nAction Redone.");
            }
        }
    }
}
