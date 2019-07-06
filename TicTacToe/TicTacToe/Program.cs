using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    class Program {
        static void Main(string[] args) {
            bool playAgain = false;
            do {
                Game Game = new Game();
                Game.PlayMatch();
                Game.DisplayResults();
                playAgain = Game.PlayAgain();
                CommandInvoker.Singleton.ClearHistory();
            } while (playAgain);
        }
    }

    class Game {
        readonly InputHandler inputHandler = new InputHandler();

        public bool PlayAgain() {
            char input;
            do {
                input = Char.ToLower(Console.ReadKey().KeyChar);
            } while (input != 'y' && input != 'n');
            return input == 'y';
        }

        public void PlayMatch() {
            Board.Singleton.ClearBoard();
            do {
                TakeTurn();
            } while (!EndState());
        }

        private bool EndState() => (Players.None != Board.Singleton.CheckForWinner()) || !Board.Singleton.EmptySquareExists();

        public void DisplayResults() {
            Board.Singleton.DrawBoard();
            if (Players.None != Board.Singleton.CheckForWinner()) {
                Console.WriteLine("{0} is the winner! \nPlay again? Y/N", Board.Singleton.CheckForWinner().ToString());
            }
            else if (!Board.Singleton.EmptySquareExists()) {
                Console.WriteLine("The game is a Draw. \nPlay again? Y/N");
            }
            else {
                Console.WriteLine("If you see this an error occured... \nPlay again? Y/N");
            }
        }

        private void TakeTurn() {
            ICommand command;
            char input;
            Board.Singleton.DrawBoard();
            Console.WriteLine("Player {0}'s turn.", Board.Singleton.CurrentPlayer.ToString());
            do {
                input = Console.ReadKey().KeyChar;
                command = inputHandler.HandleInput(input);
            } while (command == null);
            Execute(command);
        }

        private static void Execute(ICommand command) {
            if (command is UndoCommand)
                CommandInvoker.Singleton.Undo();
            else if (command is RedoCommand)
                CommandInvoker.Singleton.Redo();
            else {
                CommandInvoker.Singleton.SetCommand(command);
                CommandInvoker.Singleton.Invoke();
            }
        }
    }
}
