using System;
using System.Windows;
using System.Windows.Controls;

using NuGet;

namespace NuGetPackageExplorer.Plugins.DeleteCommand.Controls
{
  /// <summary>
  /// Interaction logic for SettingsControl.xaml
  /// </summary>
  public partial class SettingsControl : UserControl
  {
    private readonly IPackage _package;

    private readonly string _packagePath;

    public SettingsControl()
    {
      InitializeComponent();
    }

    public SettingsControl(IPackage package, string packagePath)
      : this()
    {
      _package = package;
      _packagePath = packagePath;

      // TODO: add some proper binding

      QuestionLabel.Content = string.Format("Are you sure you want to remove package [{0}, {1}] from source?", _package.Id, _package.Version);

      SourceText.Text = GetPackageSource(_packagePath);

      ApiKeyText.Text = _package.Id;
    }

    public Window ParentWindow
    {
      get
      {
        return Parent as Window;
      }
    }

    private string GetPackageSource(string packagePath)
    {
      // TODO: parse source url from path
      return packagePath;
    }

    private void OnButtonOkClick(object sender, RoutedEventArgs e)
    {
      try
      {
        // TODO: execute delete command
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    private void OnButtonCancelClick(object sender, RoutedEventArgs e)
    {
      try
      {
        if (ParentWindow != null)
        {
          ParentWindow.Close();
        }
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}