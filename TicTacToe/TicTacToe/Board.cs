using System;

namespace TicTacToe {
    public sealed class Board {
        private static Board instance = null;
        private static readonly object padlock = new object();

        private Board() { }

        public static Board Instance {
            get {
                lock (padlock) {
                    if (instance == null) {
                        instance = new Board();
                    }
                    return instance;
                }
            }
        }

        private Players CurrentPlayer { get; } = Players.X;

        public void TogglePlayer() {
            CurrentPlayer = CurrentPlayer == Players.X ? Players.O : Players.X;
        }

        private readonly string[] BoardLines = new[] {
                " {0} | {1} | {2} ",
                "   |   |   ",
                "---+---+---",
                "   |   |   ",
                " {0} | {1} | {2} ",
                "   |   |   ",
                "---+---+---",
                "   |   |   ",
                " {0} | {1} | {2} ",
            };

        private string[] BoardCells = new[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", };

        public void ClearBoard() {
            for (int cellIndex = 0; cellIndex < BoardCells.Length; cellIndex++) {
                BoardCells[cellIndex] = " ";
            }
        }

        public void DrawBoard() {
            Console.WriteLine();
            Console.WriteLine();
            for (int boardLineIndex = 0; boardLineIndex < 9; boardLineIndex++) {
                if (boardLineIndex % 4 == 0)
                    Console.WriteLine(String.Format(BoardLines[boardLineIndex], BoardCells[GetCurrentMarkBaseIndex(boardLineIndex) + 0], BoardCells[GetCurrentMarkBaseIndex(boardLineIndex) + 1], BoardCells[GetCurrentMarkBaseIndex(boardLineIndex) + 2]));
                else
                    Console.WriteLine(BoardLines[boardLineIndex]);
            }
        }

        public bool EmptySquareExists() {
            foreach (string square in BoardCells)
                if (square == " ")
                    return true;
            return false;
        }

        public Players CheckForWinner() {
            if (IsSelectedPlayerWinner(Players.X))
                return Players.X;
            if (IsSelectedPlayerWinner(Players.O))
                return Players.O;
            return Players.None;
        }

        private bool IsSelectedPlayerWinner(Players player) {
            string playerKey = player.ToString("G");

            for (int cellIndex = 0; cellIndex < 9; cellIndex += 3)
                if (BoardCells[cellIndex] == playerKey && BoardCells[cellIndex + 1] == playerKey && BoardCells[cellIndex + 2] == playerKey)
                    return true;
            for (int cellIndex = 0; cellIndex < 3; cellIndex++)
                if (BoardCells[cellIndex] == playerKey && BoardCells[cellIndex + 3] == playerKey && BoardCells[cellIndex + 6] == playerKey)
                    return true;
            if (BoardCells[0] == playerKey && BoardCells[4] == playerKey && BoardCells[8] == playerKey)
                return true;
            if (BoardCells[2] == playerKey && BoardCells[4] == playerKey && BoardCells[6] == playerKey)
                return true;
            return false;
        }

        public void SetCell(int index, string mark) => BoardCells[index] = mark;
        private int GetCurrentMarkBaseIndex(int boardLineIndex) => ((boardLineIndex / 4) * 3);
        public bool SelectedSlotIsFree(int index) => BoardCells[index] == " " ? true : false;
    }
}
