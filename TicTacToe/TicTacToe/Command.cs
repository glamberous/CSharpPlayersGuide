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
            if (Board.Singleton.SelectedSlotIsFree(index)) {
                Board.Singleton.SetCell(index, Board.Singleton.CurrentPlayer.ToString());
                Board.Singleton.TogglePlayer();
            }
        }

        public void UndoAction() {
            Board.Singleton.SetCell(index, " ");
            Board.Singleton.TogglePlayer();
        }
    }

    public class UndoCommand : ICommand {
        public void ExecuteAction() { }
        public void UndoAction() { }
    }

    public class RedoCommand : ICommand {
        public void ExecuteAction() { }
        public void UndoAction() { }
    }
}