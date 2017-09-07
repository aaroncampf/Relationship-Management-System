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
		public frmBrowser() {
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {


			var HTMLGetter = new Relationship_Management_System.Classes.IStringVisitor_Implimentation();
			wbrMain.GetBrowser().MainFrame.GetSource(HTMLGetter);

			var test = HTMLGetter.Value;
			test.ToString();



			//wbrMain.Address;
			//wbrMain.GetBrowser().go
		}

		private void wbrMain_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e) {
			if (e.Frame.IsMain) {

			}
		}
	}
}
