using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using NuGet;
using NuGetPackageExplorer.MvvmSupport;
using NuGetPackageExplorer.MvvmSupport.Command;

namespace NuGetPackageExplorer.Plugins.DeleteCommand.Controls
{
  public class SettingsViewModel : ViewModelBase
  {
    private string _apiKey;
    private string _question;
    private string _packageSource;
    private IPackage _package;

    public Command Execute { get; private set; }
    public Command<Window> Cancel { get; private set; } 

    public SettingsViewModel(PackageInfo packageInfo)
    {
      _package = packageInfo.Package;
      PackageSource = GetPackageSource(packageInfo.PackagePath);
      Question = string.Format("Are you sure you want to remove package [{0}, {1}] from source?", _package.Id, _package.Version);

      Execute = new Command(ExecuteCommandExecute, CanExecuteCommandExecute);
      Cancel = new Command<Window>(CancelCommandExecute);
    }
    
    public string PackageSource
    {
      get
      {
        return _packageSource;
      }
      set
      {
        _packageSource = value;
        OnPropertyChanged(() => PackageSource);
      }
    }
    
    public string ApiKey
    {
      get
      {
        return _apiKey;
      }
      set
      {
        _apiKey = value;
        OnPropertyChanged(() => ApiKey);
      }
    }
    
    public string Question
    {
      get
      {
        return _question;
      }
      set
      {
        _question = value;
        OnPropertyChanged(() => Question);
      }
    }

    private string GetPackageSource(string packagePath)
    {
      int patternIndex;
      if ((patternIndex = packagePath.IndexOf(@"/api/", System.StringComparison.Ordinal)) == -1)
      {
        return string.Empty;
      }

      return packagePath.Substring(0, patternIndex);
    }

    private bool CanExecuteCommandExecute()
    {
      return !(String.IsNullOrEmpty(PackageSource) || String.IsNullOrEmpty(ApiKey));
    }

    private void ExecuteCommandExecute()
    {
      
    }

    private void CancelCommandExecute(Window view)
    {
      view.Close();
    }
  }
}