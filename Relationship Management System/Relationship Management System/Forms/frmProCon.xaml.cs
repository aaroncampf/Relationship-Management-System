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
	/// Interaction logic for frmProCon.xaml
	/// </summary>
	public partial class frmProCon : UserControl {
		private MainWindow ParentWindow;
		private System.Windows.Controls.Ribbon.RibbonTab MyRibbonTab;
		private Database.Database db = new Database.Database();
		//private ObservableCollection<Database.ProCon> ProConList = new ObservableCollection<Database.ProCon>();


		public frmProCon() {
			InitializeComponent();

			db.ProsCons.ToArray();
			proConDataGrid.ItemsSource = db.ProsCons.Local;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			ParentWindow = Window.GetWindow(this) as MainWindow;

			MyRibbonTab = new System.Windows.Controls.Ribbon.RibbonTab() { Header = "Pro/Con" };
			ParentWindow.Ribbon.Items.Add(MyRibbonTab);
			ParentWindow.Ribbon.SelectedItem = MyRibbonTab;

			var NewRibbonGroup = new System.Windows.Controls.Ribbon.RibbonGroup() { Header = "Pro/Con" };
			MyRibbonTab.Items.Add(NewRibbonGroup);

			var SaveRibbonButton = new System.Windows.Controls.Ribbon.RibbonButton() { Label = "Save" };
			NewRibbonGroup.Items.Add(SaveRibbonButton);
			SaveRibbonButton.Click += (object sender1, RoutedEventArgs e1) => { db.SaveChanges(); };
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e) {
			ParentWindow.Ribbon.Items.Remove(MyRibbonTab);
		}
	}
}
