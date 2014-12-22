using System;
using System.Windows.Input;

namespace NuGetPackageExplorer.MvvmSupport.Command
{
  public class Command<T> : ICommand
  {
    private readonly Action<T> _method;
    private readonly Func<T, bool> _canExecuteMethod;

    public Command(Action<T> method)
      : this(method, (x) => true)
    {
    }

    public Command(Action<T> method, Func<T, bool> canExecuteMethod)
    {
      _method = method;
      _canExecuteMethod = canExecuteMethod;
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
      T parameterOfT = (T)parameter;
      return _canExecuteMethod(parameterOfT);
    }

    public void Execute(object parameter)
    {
      T parameterOfT = (T)parameter;
      _method(parameterOfT);
    }
  }
}
