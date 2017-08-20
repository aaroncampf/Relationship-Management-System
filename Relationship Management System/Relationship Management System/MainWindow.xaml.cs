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

namespace Relationship_Management_System {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void btnEditInterests_Click(object sender, RoutedEventArgs e) {
      var Form = new Forms.frmInterests();
      Form.ShowDialog();


    }

    private void btnGenerateMessage_Click(object sender, RoutedEventArgs e) {
      var Form = new Forms.frmGenerateMessage();
      Form.ShowDialog();
    }
  }
}
