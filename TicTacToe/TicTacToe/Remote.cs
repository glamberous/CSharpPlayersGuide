using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    class CommandInvoker {
        private readonly List<ICommand> commands;
        private ICommand command;

        public CommandInvoker() => commands = new List<ICommand>();
        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke() {
            commands.Add(command);
            command.ExecuteAction();
        }
    }
}
