using System;

namespace NuGetPackageExplorer.MvvmSupport.Extensions.Unity
{
  internal class ViewContainer
  {
    public string Id { get; set; }

    public string ViewModelName { get; set; }

    public Func<object> ViewFactory { get; set; }
  }
}
