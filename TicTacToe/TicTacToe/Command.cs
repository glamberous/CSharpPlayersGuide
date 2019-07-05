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
        private readonly int index;

        public MarkCommand(int index) {
            this.index = index;
        }

        public void ExecuteAction() {
            if (Board.Instance.SelectedSlotIsFree(index)) {
                Board.Instance.SetCell(index, Board.Instance.CurrentPlayer.ToString());
                Board.Instance.TogglePlayer();
            }
        }

        public void UndoAction() {
            Board.Instance.SetCell(index, " ");
            Board.Instance.TogglePlayer();
        }
    }
}