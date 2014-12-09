using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetPackageExplorer.MvvmSupport.Configuration
{
  public class Context
  {
    private static IUnityContainer _container;

    public static void Initialize(IUnityContainer container)
    {
      _container = container;
    }

    internal static IUnityContainer Container { get { return _container; } }
  }
}
