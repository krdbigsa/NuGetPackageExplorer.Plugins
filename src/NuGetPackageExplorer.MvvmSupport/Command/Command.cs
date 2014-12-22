using System;

namespace NuGetPackageExplorer.MvvmSupport.Command
{
  public class Command : Command<object>
  {
    public Command(Action method) : base((o) => method())
    {
    }

    public Command(Action method, Func<bool> canExecuteMethod) : base((o) => method(), (o) => canExecuteMethod())
    {
    }
  }
}
