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
using System.Collections.Specialized;
using System.Configuration;
using Clean.Architecture.Infrastructure.Data;

namespace Clean.Architecture.Wpf
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var mod = (ViewModels.MainWindowViewModel)Resources["mainWinVM"];
      mod.Projects.Add(new ViewModels.ProjectProxy(new Core.ProjectAggregate.Project("AddProj")));
      ((Label)AppStatusBar.Items[0]).Content = ProjectsList.ItemsSource.ToString();
    }
  }
}
