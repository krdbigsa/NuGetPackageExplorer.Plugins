using System;
using Microsoft.Practices.Unity;
using NuGetPackageExplorer.MvvmSupport;

namespace NuGetPackageExplorer.Plugins
{
  public abstract class PluginCommand
  {
    private static IUnityContainer _container;
    private static bool _initialized = false;
    private static Type _mainViewModelType;

    protected PluginCommand()
    {
      if (_container == null)
      {
        _container = new UnityContainer();
        MvvmSupport.Configuration.Context.Initialize(_container);
      }

      if (_initialized)
      {
        return;
      }

      RegisterTypes(_container);
      RegisterViewModels(_container);
      _initialized = true;
    }

    protected ViewModelBase MainViewModel
    {
      get
      {
        if (_mainViewModelType != null)
        {
          return (ViewModelBase)_container.Resolve(_mainViewModelType);
        }

        return null;
      }
    }

    protected IUnityContainer Container
    {
      get { return _container; }
    }

    protected virtual void RegisterViewModels(IUnityContainer container)
    {
    }

    protected virtual void RegisterTypes(IUnityContainer container)
    {
    }

    protected void SetMainViewModel<T>() where T : ViewModelBase
    {
      _mainViewModelType = typeof(T);
    }
  }
}
