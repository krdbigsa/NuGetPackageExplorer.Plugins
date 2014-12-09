using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;

namespace NuGetPackageExplorer.Plugins.DeleteCommand
{
  public class PackageInfo
  {
    public IPackage Package { get; set; }
    public string PackagePath { get; set; }
  }
}
