using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Relationship_Management_System.Forms {
	/// <summary>
	/// Interaction logic for frmLocations.xaml
	/// </summary>
	public partial class frmLocations : UserControl {
		private Database.Database db = new Database.Database();
		private string[] Statuses = Enum.GetNames(typeof(Database.RelationshipState));


		public frmLocations() {
			InitializeComponent();

			db.Locations.ToArray();
			locationDataGrid.ItemsSource = db.Locations.Local;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {

			// Do not load your data at design time.
			// if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
			// {
			// 	//Load your data here and assign the result to the CollectionViewSource.
			// 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
			// 	myCollectionViewSource.Source = your data
			// }
		}

		private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			var Content = (e.AddedItems[0] as ComboBoxItem).Content.ToString().Replace(" ", "_");
			Database.ActivityType Value;
			Enum.TryParse(Content, out Value);

			var Location = locationDataGrid.SelectedItem as Database.Location;
			Location.Type = Value;
		}
	}
}
