using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    class CommandInvoker {
        private static CommandInvoker singleton = null;
        private static readonly object padlock = new object();

        private CommandInvoker() => commands = new ICommand[10];

        public static CommandInvoker Singleton {
            get {
                lock (padlock) {
                    if (singleton == null) {
                        singleton = new CommandInvoker();
                    }
                    return singleton;
                }
            }
        }

        private readonly ICommand[] commands;
        private int commandIndex = 0;

        public void SetCommand(ICommand command) => commands[commandIndex] = command;
        private void IncrementIndex() => commandIndex = commandIndex != 9 ? commandIndex + 1 : 0;
        private void DecrementIndex() => commandIndex = commandIndex != 0 ? commandIndex - 1 : 9;

        public void ClearHistory() {
            for (int commandIndex = 0; commandIndex < commands.Length; commandIndex++) {
                commands[commandIndex] = null;
            }
        }

        public void Invoke() {
            commands[commandIndex].ExecuteAction();
            IncrementIndex();
            commands[commandIndex] = null;
        }

        public void Undo() {
            DecrementIndex();
            if (commands[commandIndex] != null) {
                commands[commandIndex].UndoAction();
                Console.WriteLine("Action Undone.");
            } else {
                IncrementIndex();
            }
            
        }

        public void Redo() {
            if (commands[commandIndex] != null) {
                commands[commandIndex].ExecuteAction();
                IncrementIndex();
                Console.WriteLine("Action Redone.");
            }
        }
    }
}
