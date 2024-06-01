using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RVAProject.ClientApp.Modules
{
    public class AppAsyncCommand : ICommand
    {
        private readonly Func<Task> _executeMethodAsync;
        private readonly Func<bool> _canExecuteMethod;

        public AppAsyncCommand(Func<Task> executeMethodAsync)
        {
            _executeMethodAsync = executeMethodAsync;
        }

        public AppAsyncCommand(Func<Task> executeMethodAsync, Func<bool> canExecuteMethod)
        {
            _executeMethodAsync = executeMethodAsync;
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

        async void ICommand.Execute(object parameter)
        {
            if (_executeMethodAsync != null)
            {
                await _executeMethodAsync();
            }
        }
    }

    public class AppAsyncCommand<T> : ICommand
    {
        private readonly Func<T, Task> _TargetExecuteMethodAsync;
        private readonly Func<T, bool> _TargetCanExecuteMethod;

        public AppAsyncCommand(Func<T, Task> executeMethodAsync)
        {
            _TargetExecuteMethodAsync = executeMethodAsync;
        }

        public AppAsyncCommand(Func<T, Task> executeMethodAsync, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethodAsync = executeMethodAsync;
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

            return _TargetExecuteMethodAsync != null;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        async void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethodAsync != null && parameter is T tparm)
            {
                await _TargetExecuteMethodAsync(tparm);
            }
        }

        #endregion
    }
}
