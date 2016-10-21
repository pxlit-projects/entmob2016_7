using System;
using System.Windows.Input;

namespace FitSense_UWP.Utility
{
    public class AlwaysRunCommand : ICommand
    {
        private Action<object> execute;

        public event EventHandler CanExecuteChanged;

        public AlwaysRunCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}