using System;
using System.Windows.Input;

namespace RoseOrganizer.Commands {
    public class RelayCommand : ICommand {

        // Event Handler
        public event EventHandler CanExecuteChanged;
        
        // Action & Predicate
        private Action<object> _execute { get; set; }
        private Predicate<object> _canExecute { get; set; }

        // Bool and Void Execute
        public bool CanExecute(object parameter) { return _canExecute(parameter); }
        public void Execute(object parameter) { _execute(parameter); }
        
        // RelayCommand Function Action
        public RelayCommand(Action<object> ExecuteMethod, Predicate<object> CanExecuteMethod) { 
            _execute = ExecuteMethod; _canExecute = CanExecuteMethod;
        }
    }
}
