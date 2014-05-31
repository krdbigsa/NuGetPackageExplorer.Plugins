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
    private SettingsViewModel _settingsViewModel;
    public SettingsControl()
    {
      InitializeComponent();
    }

    public SettingsControl(SettingsViewModel viewModel)
      : this()
    {
      _settingsViewModel = viewModel;

      DataContext = _settingsViewModel;
    }

    public Window ParentWindow
    {
      get
      {
        return Parent as Window;
      }
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