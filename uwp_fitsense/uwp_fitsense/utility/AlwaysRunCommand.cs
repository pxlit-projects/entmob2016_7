using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace uwp_fitsense.utility
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
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
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