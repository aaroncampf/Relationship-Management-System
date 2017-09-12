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

namespace Relationship_Management_System.Forms {
	/// <summary>
	/// Interaction logic for Browser.xaml
	/// </summary>
	public partial class frmBrowser : UserControl {
		private System.Windows.Controls.Ribbon.RibbonTab MyRibbonTab;
		private MainWindow ParentWindow;
		Database.Database Database = new Database.Database();

		private string HTML;

		public frmBrowser() {
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			ParentWindow = Window.GetWindow(this) as MainWindow;

			MyRibbonTab = new System.Windows.Controls.Ribbon.RibbonTab() { Header = "Browser" };
			ParentWindow.Ribbon.Items.Add(MyRibbonTab);
			ParentWindow.Ribbon.SelectedItem = MyRibbonTab;

			var rgpOkCupid = new System.Windows.Controls.Ribbon.RibbonGroup() { Header = "OkCupid" };
			MyRibbonTab.Items.Add(rgpOkCupid);

			var btnGenerateMessage = new System.Windows.Controls.Ribbon.RibbonButton() { Label = "Generate Message" };
			rgpOkCupid.Items.Add(btnGenerateMessage);
			btnGenerateMessage.Click += btnGenerateMessage_Click;
		}

		void btnGenerateMessage_Click(object sender, RoutedEventArgs e) {
			var Contact = Database.ContactedProfiles.FirstOrDefault(x => x.URL == wbrMain.Address);

			if (Contact != null && Contact.LastContacted < DateTime.Now.AddMinutes(-10)) {
				MessageBox.Show("You have already contacted this person", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else {
				var Message = new Classes.Message(wbrMain.Address, Database.Interests.ToList());
				if (Contact == null) {
					Database.ContactedProfiles.Add(new Database.ContactedProfiles() { URL = wbrMain.Address, LastContacted = DateTime.Now });
				}
				else {
					Contact.LastContacted = DateTime.Now;
				}

				Database.SaveChanges();
				Clipboard.SetText(Message.GetResponse());
			}
		}
		private void wbrMain_FrameLoadStart(object sender, CefSharp.FrameLoadStartEventArgs e) {
			HTML = null;
		}

		private void wbrMain_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e) {
			if (e.Frame.IsMain) {
				e.Frame.Browser.MainFrame.GetSourceAsync().ContinueWith(x => {
					HTML = x.Result;
				});
			}
		}

		private void txtGo_Click(object sender, RoutedEventArgs e) {
			wbrMain.Load(txtAddress.Text);
		}
	}
}
