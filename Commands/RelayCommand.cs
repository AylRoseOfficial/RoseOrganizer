using System;
using System.Windows.Input;

namespace RoseOrganizer.Commands {
    public class RelayCommand : ICommand {


        public event EventHandler CanExecuteChanged;
        private Action<object> _execute { get; set; }
        private Predicate<object> _canExecute { get; set; }

        /// Commando de Relay
        public RelayCommand(Action<object> ExecuteMethod, Predicate<object> CanExecuteMethod) { 
            _execute = ExecuteMethod;
            _canExecute = CanExecuteMethod;
        }

        public bool CanExecute(object parameter) { return _canExecute(parameter); }
        public void Execute(object parameter) { _execute(parameter); }
    }
}
