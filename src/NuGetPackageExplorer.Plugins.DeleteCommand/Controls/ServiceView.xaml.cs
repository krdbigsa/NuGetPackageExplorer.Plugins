using System.Windows.Controls;

namespace NuGetPackageExplorer.Plugins.DeleteCommand.Controls
{
  /// <summary>
  /// Interaction logic for ServiceView.xaml
  /// </summary>
  public partial class ServiceView : UserControl
  {
    public ServiceView()
    {
      InitializeComponent();
      SourceText.Focus();
    }
  }
}
