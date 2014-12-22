using NuGet;

namespace NuGetPackageExplorer.Plugins.DeleteCommand
{
  public class PackageInfo
  {
    public IPackage Package { get; set; }

    public string PackagePath { get; set; }
  }
}
