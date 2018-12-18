using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MahAppsDialogBottomBug
{
  using MahApps.Metro.Controls;
  using MahApps.Metro.Controls.Dialogs;

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : MetroWindow
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private async void StartDemo_OnClick(object sender, RoutedEventArgs e)
    {
      var demoDialog = new DemoDialog(this);
      await this.ShowMetroDialogAsync(demoDialog, demoDialog.DialogSettings).ConfigureAwait(continueOnCapturedContext: true);
      await demoDialog.WaitUntilUnloadedAsync().ConfigureAwait(continueOnCapturedContext: true);
    }
  }
}
