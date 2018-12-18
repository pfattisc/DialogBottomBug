using System.Windows.Input;

namespace MahAppsDialogBottomBug
{
  using System.ComponentModel;
  using System.Runtime.CompilerServices;

  using MahApps.Metro.Controls;
  using MahApps.Metro.Controls.Dialogs;

  /// <summary>
  /// Interaction logic for DemoDialog.xaml
  /// </summary>
  public partial class DemoDialog : BaseMetroDialog, INotifyPropertyChanged
  {
    private ICommand closeCommand;

    public DemoDialog(MetroWindow owningWindow) : base(owningWindow, new MetroDialogSettings() { AnimateShow = false, AnimateHide = false })
    {
      this.InitializeComponent();
      this.CloseCommand = new RelayCommand<bool>(this.Close, b => true);
    }

    public ICommand CloseCommand
    {
      get { return this.closeCommand; }
      private set
      {
        if (this.closeCommand != value)
        {
          this.closeCommand = value;
          this.OnPropertyChanged("CloseCommand");
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>Closes the dialog.</summary>
    /// <param name="confirmed">Flag indicating whether the user confirmed the dialog.</param>
    private void Close(bool confirmed)
    {
      this.OwningWindow.HideMetroDialogAsync(this, this.DialogSettings);
    }

  }
}
