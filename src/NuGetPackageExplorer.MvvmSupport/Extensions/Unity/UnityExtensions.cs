using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace NuGetPackageExplorer.MvvmSupport.Extensions.Unity
{
  public static class UnityExtensions
  {
    private static Dictionary<string, ViewContainer> _registeredViewModels = new Dictionary<string, ViewContainer>();

    public static void RegisterViewModel<TViewModel, TView>(this IUnityContainer unity, params InjectionMember[] injectionMembers)
    {
      if (!unity.IsRegistered<TViewModel>())
      {
        unity.RegisterType<TViewModel>(injectionMembers);
      }

      if (!unity.IsRegistered<TView>())
      {
        unity.RegisterType<TView>(injectionMembers);
      }

      _registeredViewModels.Add(typeof(TViewModel).Name, new ViewContainer() { Id = typeof(TView).Name, ViewModelName = typeof(TViewModel).Name, ViewFactory = ViewFactory<TView>(unity.Resolve<Func<TView>>()) });
    }

    public static void RegisterViewModel<TViewModel, TView>(this IUnityContainer unity, LifetimeManager viewModelLifetimeManager, LifetimeManager viewLifetimeManager, params InjectionMember[] injectionMembers)
    {
      if (!unity.IsRegistered<TViewModel>())
      {
        unity.RegisterType<TViewModel>(viewModelLifetimeManager, injectionMembers);
      }

      if (!unity.IsRegistered<TView>())
      {
        unity.RegisterType<TView>(viewLifetimeManager, injectionMembers);
      }

      _registeredViewModels.Add(typeof(TViewModel).Name, new ViewContainer() { Id = typeof(TView).Name, ViewModelName = typeof(TViewModel).Name, ViewFactory = ViewFactory<TView>(unity.Resolve<Func<TView>>()) });
    }

    public static object ResolveView<TViewModel>(this IUnityContainer unity)
    {
      return unity.ResolveView(typeof(TViewModel));
    }

    public static object ResolveView(this IUnityContainer unity, Type viewModelType)
    {
      ViewContainer view;
      if (!_registeredViewModels.TryGetValue(viewModelType.Name, out view))
      {
        throw new Exception(String.Format("Type {0} is not registered as a view model", viewModelType.Name));
      }

      return view.ViewFactory();
    }

    internal static Func<object> ViewFactory<TView>(Func<TView> viewFactory)
    {
      if (viewFactory == null)
      {
        throw new ArgumentNullException("viewFactory");
      }

      return () => viewFactory();
    }
  }
}
