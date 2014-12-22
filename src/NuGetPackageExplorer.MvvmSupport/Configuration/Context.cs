using Microsoft.Practices.Unity;

namespace NuGetPackageExplorer.MvvmSupport.Configuration
{
  public class Context
  {
    private static IUnityContainer _container;

    internal static IUnityContainer Container
    {
      get
      {
        return _container;
      }
    }

    public static void Initialize(IUnityContainer container)
    {
      _container = container;
    }
  }
}
