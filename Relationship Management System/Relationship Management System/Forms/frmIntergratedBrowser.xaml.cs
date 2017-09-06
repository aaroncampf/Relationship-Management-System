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
	/// Interaction logic for frmIntergratedBrowser.xaml
	/// </summary>
	public partial class frmIntergratedBrowser : UserControl {
		private MainWindow ParentWindow;
		private System.Windows.Controls.Ribbon.RibbonTab MyRibbonTab;
		private Database.Database Database = new Database.Database();

		public frmIntergratedBrowser() {
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			ParentWindow = Window.GetWindow(this) as MainWindow;
			MyRibbonTab = new System.Windows.Controls.Ribbon.RibbonTab() { Header = "Embedded Browser" };
			ParentWindow.Ribbon.Items.Add(MyRibbonTab);
			ParentWindow.Ribbon.SelectedItem = MyRibbonTab;

			var NewRibbonGroup = new System.Windows.Controls.Ribbon.RibbonGroup() { Header = "Dating" };
			MyRibbonTab.Items.Add(NewRibbonGroup);

			var SaveRibbonButton = new System.Windows.Controls.Ribbon.RibbonButton() { Label = "Parse" };
			NewRibbonGroup.Items.Add(SaveRibbonButton);
			SaveRibbonButton.Click += SaveRibbonButton_Click;

			wbrMain.Source = new Uri(@"https:\\www.google.com");
		}

		void SaveRibbonButton_Click(object sender, RoutedEventArgs e) {
			var Contact = Database.ContactedProfiles.FirstOrDefault(x => x.URL == wbrMain.Source.AbsoluteUri);
			if (Contact != null && Contact.LastContacted < DateTime.Now.AddMinutes(-10)) {
				MessageBox.Show("You have already contacted this person", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else {
				Uri uriResult;
				bool result = Uri.TryCreate(wbrMain.Source.AbsoluteUri, UriKind.RelativeOrAbsolute, out uriResult);
				if (result) {
					var Message = new Classes.Message(wbrMain.Source.AbsoluteUri, Database.Interests.ToList());
					if (Contact == null) {
						Database.ContactedProfiles.Add(new Database.ContactedProfiles() { URL = wbrMain.Source.AbsoluteUri, LastContacted = DateTime.Now });

					}
					else {
						Contact.LastContacted = DateTime.Now;
					}

					Database.SaveChanges();
					Clipboard.SetText(Message.GetResponce());
				}
			}
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e) {
			ParentWindow.Ribbon.Items.Remove(MyRibbonTab);
		}

	}
}
