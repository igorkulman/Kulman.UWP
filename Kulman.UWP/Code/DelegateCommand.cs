using System;
using System.Windows.Input;

namespace Kulman.UWP.Code
{
    public class DelegateCommand : ICommand
    {
        readonly Func<object, bool> _canExecute;
        readonly Action<object> _executeAction;

        public DelegateCommand(Action<object> executeAction)
            : this(executeAction, null)
        {
        }

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction");
            }
            this._executeAction = executeAction;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            var result = true;
            var canExecuteHandler = this._canExecute;
            if (canExecuteHandler != null)
            {
                result = canExecuteHandler(parameter);
            }

            return result;
        }

        public event EventHandler CanExecuteChanged = delegate { };
        public void RaiseCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;
            handler(this, new EventArgs());
        }

        public void Execute(object parameter)
        {
            this._executeAction(parameter);
        }
    }
}
