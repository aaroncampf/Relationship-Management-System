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
	//TODO: Try replacing the browser with https://cefsharp.github.io/


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

			var rgpDating = new System.Windows.Controls.Ribbon.RibbonGroup() { Header = "Dating" };
			MyRibbonTab.Items.Add(rgpDating);

			var btnParse = new System.Windows.Controls.Ribbon.RibbonButton() { Label = "Parse" };
			btnParse.Click += btnParse_Click;
			rgpDating.Items.Add(btnParse);

			var btnLookupProfile = new System.Windows.Controls.Ribbon.RibbonButton() { Label = "Lookup Profile" };
			btnLookupProfile.Click += btnLookupProfile_Click;
			rgpDating.Items.Add(btnLookupProfile);


			wbrMain.Source = new Uri(@"https:\\www.google.com");
		}

		void btnParse_Click(object sender, RoutedEventArgs e) {
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

		void btnLookupProfile_Click(object sender, RoutedEventArgs e) {
			throw new NotImplementedException();
		}



		private void UserControl_Unloaded(object sender, RoutedEventArgs e) {
			ParentWindow.Ribbon.Items.Remove(MyRibbonTab);
		}

		private void wbrMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e) {

		}

		private void btnBack_Click(object sender, RoutedEventArgs e) {

		}

		private void btnForward_Click(object sender, RoutedEventArgs e) {

		}

		private void txtAddressBar_KeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Enter) {
				var URI = new Uri(txtAddressBar.Text);
				wbrMain.Navigate(URI);
			}
		}


	}
}
