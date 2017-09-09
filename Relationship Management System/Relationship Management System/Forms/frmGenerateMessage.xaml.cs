using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Interaction logic for frmGenerateMessage.xaml
	/// </summary>
	public partial class frmGenerateMessage : Window {
		Database.Database Database = new Database.Database();

		public frmGenerateMessage() {
			InitializeComponent();
		}

		private void txtURL_TextChanged(object sender, TextChangedEventArgs e) {
			var Contact = Database.ContactedProfiles.FirstOrDefault(x => x.URL == txtURL.Text);

			if (Contact != null && Contact.LastContacted < DateTime.Now.AddMinutes(-10)) {
				MessageBox.Show("You have already contacted this person", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else {
				Uri uriResult;
				bool result = Uri.TryCreate(txtURL.Text, UriKind.RelativeOrAbsolute, out uriResult);
				if (result) {
					var Message = new Classes.Message(txtURL.Text, Database.Interests.ToList());
					if (Contact == null) {
						Database.ContactedProfiles.Add(new Database.ContactedProfiles() { URL = txtURL.Text, LastContacted = DateTime.Now });

					}
					else {
						Contact.LastContacted = DateTime.Now;
					}

					Database.SaveChanges();
					Clipboard.SetText(Message.GetResponce());
				}
			}
		}

		private void Window_Deactivated(object sender, EventArgs e) {
			Window window = (Window)sender;
			window.Topmost = true;
		}
	}
}
