using System.Windows.Media;
using NuGetPackageExplorer.MvvmSupport.Configuration;
using NuGetPackageExplorer.MvvmSupport.Extensions.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NuGetPackageExplorer.MvvmSupport
{
  public class ViewModelBase : PropertyChangedNotificator
  {
    public void ShowDialog()
    {
      object view = Context.Container.ResolveView(this.GetType());
      if (view != null)
      {
        if (view is Window)
        {
          Window window = (Window)view;
          window.DataContext = this;
          window.ShowDialog();
        }
        else if (view is FrameworkElement)
        {
          Window window = new Window();
          window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
          //window.AllowsTransparency = true;
          //window.WindowStyle = WindowStyle.None;
          //window.BorderThickness = new Thickness(1);
          //window.BorderBrush = Brushes.Black;
          window.ResizeMode = ResizeMode.NoResize;
          window.SizeToContent = SizeToContent.WidthAndHeight;
          window.ShowInTaskbar = false;
          window.Topmost = true;


          FrameworkElement control = (FrameworkElement)view;
          window.Height = control.Height;
          window.Width = control.Width;
          window.Content = control;
          control.DataContext = this;
          window.ShowDialog();
        }
      }
    }
  }
}
