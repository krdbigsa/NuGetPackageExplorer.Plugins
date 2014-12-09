using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NuGetPackageExplorer.MvvmSupport.Command
{
  public class Command<T> : ICommand
  {
    private readonly Action<T> _method;
    private readonly Func<T, bool> _canExecuteMethod;

    public Command(Action<T> method) : this(method, (x) => true) { }

    public Command(Action<T> method, Func<T, bool> canExecuteMethod)
    {
      _method = method;
      _canExecuteMethod = canExecuteMethod;
    }

    public bool CanExecute(object parameter)
    {
      return _canExecuteMethod((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
      _method((T)parameter);
    }
  }

  public class Command : Command<object>
  {
    public Command(Action method) : base((o) => method()) { }
    public Command(Action method, Func<bool> canExecuteMethod) : base((o) => method(), (o)=> canExecuteMethod()) { }
  }
}
