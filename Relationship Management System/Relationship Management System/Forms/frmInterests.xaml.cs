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
using System.Windows.Shapes;

namespace Relationship_Management_System.Forms {

	/// <summary>
	/// Interaction logic for Interests.xaml
	/// </summary>
	public partial class frmInterests : UserControl {
		private Database.Database db = new Database.Database();

		public frmInterests() {
			InitializeComponent();
			db.Interests.ToArray();
			dgdInterests.ItemsSource = db.Interests.Local;
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e) {
			db.Interests.Add(new Database.Interest { Name = "Test" });
			//dgdInterests.ItemsSource = db.Interests;
		}

		private void btnRemove_Click(object sender, RoutedEventArgs e) {

		}

		private void btnSave_Click(object sender, RoutedEventArgs e) {
			db.SaveChanges();
		}
	}
}
