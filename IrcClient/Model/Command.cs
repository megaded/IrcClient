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
        public Command(Action action)
        {
            ExecuteDelegate = action;
        }
        public event EventHandler CanExecuteChanged;
        public Action ExecuteDelegate { get; set; }
        public void Execute(object parameter)
        {
            Task.Run(()=>  ExecuteDelegate());
        }
        public bool CanExecute(object parameter)
        {
            
             return true;
        }      
    }
}
