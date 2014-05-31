using System;
using System.Windows;

using NuGet;

using NuGetPackageExplorer.Plugins.DeleteCommand.Controls;
using NuGetPackageExplorer.Types;

namespace NuGetPackageExplorer.Plugins.DeleteCommand
{
  [PackageCommandMetadata("Delete selected package...")]
  internal class DeletePackageCommand : IPackageCommand
  {
    public void Execute(IPackage package, string packagePath)
    {
      try
      {
        var settingsDialog = new Window
        {
          Content = new SettingsControl(new SettingsViewModel(package, packagePath)),
          Topmost = true,
          Width = 600,
          Height = 200,
          ResizeMode = ResizeMode.NoResize,
          WindowStartupLocation = WindowStartupLocation.CenterOwner,
          ShowInTaskbar = false
        };

        settingsDialog.ShowDialog();

      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}