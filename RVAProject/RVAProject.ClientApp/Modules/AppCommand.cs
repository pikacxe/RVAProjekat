using System;
using System.Windows.Input;

namespace RVAProject.ClientApp.Modules
{
    public class AppCommand : ICommand
    {
        private readonly Action _executeMethod;
        private readonly Func<bool> _canExecuteMethod;

        public AppCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public AppCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecuteMethod?.Invoke() ?? true;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }
    }

    public class AppCommand<T> : ICommand
    {
        private readonly Action<T> _TargetExecuteMethod;
        private readonly Func<T, bool> _TargetCanExecuteMethod;

        public AppCommand(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public AppCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null && parameter is T tparm)
            {
                return _TargetCanExecuteMethod(tparm);
            }

            return _TargetExecuteMethod != null;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null && parameter is T tparm)
            {
                _TargetExecuteMethod(tparm);
            }
        }

        #endregion
    }
}
