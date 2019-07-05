using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    public interface ICommand {
        void ExecuteAction();
        void UndoAction();
    }

    public class MarkCommand : ICommand {
        private readonly Players currentPlayer;
        private readonly int index;

        public MarkCommand(int index, Players currentPlayer) {
            this.currentPlayer = currentPlayer;
            this.index = index;
        }

        public void ExecuteAction() {
            if (Board.Instance.SelectedSlotIsFree(index)) {
                if (currentPlayer == Players.X)
                    Board.Instance.SetCell(index, "X");
                else
                    Board.Instance.SetCell(index, "O");
            } 
        }

        public void UndoAction() {
            Board.Instance.SetCell(index, " ");
        }
    }
}