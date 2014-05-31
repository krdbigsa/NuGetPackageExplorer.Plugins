using System.ComponentModel;
using System.Runtime.CompilerServices;

using NuGet;

namespace NuGetPackageExplorer.Plugins.DeleteCommand.Controls
{
  public class SettingsViewModel : INotifyPropertyChanged
  {
    private string _packageSource;

    private string _apiKey;

    private string _question;

    private IPackage _package;

    public SettingsViewModel(IPackage package, string packagePath)
    {
      _package = package;

      PackageSource = GetPackageSource(packagePath);

      Question = string.Format("Are you sure you want to remove package [{0}, {1}] from source?", _package.Id, _package.Version);
    }

    public string PackageSource
    {
      get
      {
        return _packageSource;
      }
      set
      {
        if (_packageSource == value)
        {
          return;
        }

        _packageSource = value;
        OnPropertyChanged();
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
        if (_apiKey == value)
        {
          return;
        }

        _apiKey = value;
        OnPropertyChanged();
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
        if (_question == value)
        {
          return;
        }

        _question = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
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
  }
}