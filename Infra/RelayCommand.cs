using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rolodex.Infra
{
    public class RelayCommand : ICommand
    {
        private Action localAction;
        private bool _localCanExecute;
        public RelayCommand(Action action, bool canExecute)
        {
            localAction = action;
            _localCanExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return _localCanExecute;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            localAction();
        }
    }
}
