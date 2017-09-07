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

		private void btnEditInterests1_Click(object sender, RoutedEventArgs e) {
			var Form = new Forms.frmInterests();
			ViewWindow.Content = Form;
		}

		private void btnGenerateMessage1_Click(object sender, RoutedEventArgs e) {
			var Form = new Forms.frmGenerateMessage();
			Form.ShowDialog();
		}

		private void btnTest_Click(object sender, RoutedEventArgs e) {
			//ViewWindow.Content = new Forms.TestUserControl();

			var db = new Database.Database();
			db.Interests.Any(x => x.Name == "Test");

		}

		private void btnContacts_Click(object sender, RoutedEventArgs e) {
			var Form = new Forms.frmContacts();
			ViewWindow.Content = Form;
		}

		private void btnLocations_Click(object sender, RoutedEventArgs e) {
			var Form = new Forms.frmLocations();
			ViewWindow.Content = Form;
		}

		private void btnProCon_Click(object sender, RoutedEventArgs e) {
			var Form = new Forms.frmProCon();
			ViewWindow.Content = Form;
		}

		private void btnIntergratedBrowser_Click(object sender, RoutedEventArgs e) {
			var Form = new Forms.frmIntergratedBrowser();
			ViewWindow.Content = Form;
		}

		private void btnIntergratedBrowser_Click2(object sender, RoutedEventArgs e) {
			var Form = new Forms.frmBrowser();
			ViewWindow.Content = Form;
		}
	}
}
