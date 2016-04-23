using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiChat.Model
{
    public class Command : ICommand 
    {
        private bool _chatLaunched = false;

        public Command(Action action)
        {
            ExecuteDelegate = action;
        }
        public event EventHandler CanExecuteChanged;
        public Action ExecuteDelegate { get; set; }
        public void Execute(object parameter)
        {
            Task.Run(()=>  ExecuteDelegate());
            _chatLaunched = true;
        }
        public bool CanExecute(object parameter)
        {
            if (_chatLaunched)
                return false; 
            else return true;
        }      
    }
}
