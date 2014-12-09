using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetPackageExplorer.MvvmSupport.Extensions.Unity
{
  public static class UnityExtensions
  {
    internal static Dictionary<string, ViewContainer> RegisteredViewModels = new Dictionary<string, ViewContainer>();

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

      RegisteredViewModels.Add(typeof(TViewModel).Name, new ViewContainer() { Id = typeof(TView).Name, ViewModelName = typeof(TViewModel).Name, ViewFactory = ViewFactory<TView>(unity.Resolve<Func<TView>>()) });
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

      RegisteredViewModels.Add(typeof(TViewModel).Name, new ViewContainer() { Id = typeof(TView).Name, ViewModelName = typeof(TViewModel).Name, ViewFactory = ViewFactory<TView>(unity.Resolve<Func<TView>>()) });
    }

    internal static Func<object> ViewFactory<TView>(Func<TView> viewFactory)
    {
      if (viewFactory == null)
      {
        throw new ArgumentNullException("viewFactory");
      }

      return () => viewFactory();
    }

    public static object ResolveView<TViewModel>(this IUnityContainer unity)
    {
      return unity.ResolveView(typeof(TViewModel));
    }

    public static object ResolveView(this IUnityContainer unity, Type TViewModel)
    {
      ViewContainer View;
      if (!RegisteredViewModels.TryGetValue(TViewModel.Name, out View))
      {
        throw new Exception(String.Format("Type {0} is not registered as a view model", TViewModel.Name));
      }

      return View.ViewFactory();
    }
  }

  internal class ViewContainer
  {
    public string Id { get; set; }
    public string ViewModelName { get; set; }
    public Func<object> ViewFactory { get; set; }
  }
}
