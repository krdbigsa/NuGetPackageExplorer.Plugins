using System;
using System.Windows;
using Microsoft.Practices.Unity;
using NuGet;
using NuGetPackageExplorer.MvvmSupport.Extensions.Unity;
using NuGetPackageExplorer.Plugins.DeleteCommand.Controls;
using NuGetPackageExplorer.Types;

namespace NuGetPackageExplorer.Plugins.DeleteCommand
{
  [PackageCommandMetadata("Delete selected package...")]
  internal class DeletePackageCommand : PluginCommand, IPackageCommand
  {
    public void Execute(IPackage package, string packagePath)
    {
      try
      {
        var packageInfo = new PackageInfo
        {
          Package = package, 
          PackagePath = packagePath
        };

        Container.RegisterInstance<PackageInfo>(packageInfo, new ContainerControlledLifetimeManager());
        MainViewModel.ShowDialog();
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    protected override void RegisterViewModels(Microsoft.Practices.Unity.IUnityContainer container)
    {
      container.RegisterViewModel<SettingsViewModel, ServiceView>();
      SetMainViewModel<SettingsViewModel>();
    }
  }
}