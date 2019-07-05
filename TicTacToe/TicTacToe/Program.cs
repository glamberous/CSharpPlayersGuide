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
            } while (playAgain);
        }
    }

    class Game {
        readonly CommandInvoker commandInvoker = new CommandInvoker();
        readonly InputHandler inputHandler = new InputHandler();

        public bool PlayAgain() {
            char input;
            do {
                input = Char.ToLower(Console.ReadKey().KeyChar);
            } while (input != 'y' && input != 'n');
            return input == 'y';
        }

        public void PlayMatch() {
            Board.Instance.ClearBoard();
            do {
                TakeTurn();
            } while (!EndState());
        }

        private bool EndState() => (Players.None != Board.Instance.CheckForWinner()) || !Board.Instance.EmptySquareExists();

        public void DisplayResults() {
            Board.Instance.DrawBoard();
            if (Players.None != Board.Instance.CheckForWinner()) {
                Console.WriteLine("{0} is the winner! \nPlay again? Y/N", Board.Instance.CheckForWinner().ToString());
            }
            else if (!Board.Instance.EmptySquareExists()) {
                Console.WriteLine("The game is a Draw. \nPlay again? Y/N");
            }
            else {
                Console.WriteLine("If you see this an error occured... \nPlay again? Y/N");
            }
        }

        private void TakeTurn() {
            ICommand command;
            char input;
            Board.Instance.DrawBoard();
            Console.WriteLine("Player {0}'s turn.", currentPlayer.ToString());
            do {
                input = Console.ReadKey().KeyChar;
                command = inputHandler.HandleInput(input);
            } while (command == null);
            Execute(commandInvoker, command);
        }

        private static void Execute(CommandInvoker commandInvoker, ICommand newCommand) {
            commandInvoker.SetCommand(newCommand);
            commandInvoker.Invoke();
        }
    }
}
