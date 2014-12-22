﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace NuGetPackageExplorer.MvvmSupport
{
  public class PropertyChangedNotificator : INotifyPropertyChanged, IDisposable
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void Dispose()
    {
      PropertyChanged = null;
    }

    protected void OnPropertyChanged(string name)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }

    protected void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> action)
    {
      MemberExpression expression = (MemberExpression)action.Body;
      OnPropertyChanged(expression.Member.Name);
    }
  }
}
