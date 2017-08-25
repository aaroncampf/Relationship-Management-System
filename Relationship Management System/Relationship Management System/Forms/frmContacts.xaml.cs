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
using Aaron.Reports;
using System.Collections.ObjectModel;


namespace Relationship_Management_System.Forms {
	/// <summary>
	/// Interaction logic for frmContacts.xaml
	/// </summary>
	public partial class frmContacts : UserControl {
		private Database.Database db = new Database.Database();
		private string[] Statuses = Enum.GetNames(typeof(Database.RelationshipState));
		private ObservableCollection<Database.Contact> ContactList = new ObservableCollection<Database.Contact>();
		private System.Windows.Controls.Ribbon.RibbonTab MyRibbonTab;
		private MainWindow ParentWindow;

		public frmContacts() {
			InitializeComponent();

			foreach (var item in db.Contacts.Where(x => !x.IsHidden)) {
				ContactList.Add(item);
			}

			dgdContacts.ItemsSource = ContactList;

			db.ProsCons.ToArray();
			lbxProCon.ItemsSource = db.ProsCons.Local;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			ParentWindow = Window.GetWindow(this) as MainWindow;

			MyRibbonTab = new System.Windows.Controls.Ribbon.RibbonTab() { Header = "Contacts" };
			ParentWindow.Ribbon.Items.Add(MyRibbonTab);
			ParentWindow.Ribbon.SelectedItem = MyRibbonTab;

			var NewRibbonGroup = new System.Windows.Controls.Ribbon.RibbonGroup() { Header = "Contacts" };
			MyRibbonTab.Items.Add(NewRibbonGroup);

			var SaveRibbonButton = new System.Windows.Controls.Ribbon.RibbonButton() { Label = "Save" };
			NewRibbonGroup.Items.Add(SaveRibbonButton);
			SaveRibbonButton.Click += (object sender1, RoutedEventArgs e1) => { db.SaveChanges(); };
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e) {
			ParentWindow.Ribbon.Items.Remove(MyRibbonTab);
		}

		private void DG_Hyperlink_Click(object sender, RoutedEventArgs e) {
			Hyperlink link = e.OriginalSource as Hyperlink;
		}

		private void cbxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			(dgdContacts.SelectedItem as Database.Contact).Status = (Database.RelationshipState)Enum.Parse(typeof(Database.RelationshipState), cbxStatus.Text);
		}

		private void btnContactSummary_Click(object sender, RoutedEventArgs e) {
			var SelectedContact = dgdContacts.SelectedItem as Database.Contact;

			var Report = new Aaron.Reports.Basic("Summary On " + SelectedContact.Name);
			var BasicDetails = new Aaron.Reports.Sections.Table(new TableColumn { Tag = "Key" }, new TableColumn { Tag = "Value" });
			var Table1 = BasicDetails.Table;
			Report.Sections.Add(BasicDetails);
			//Extensions.AddRow(Table: BasicDetails, RowGroupIndex: 0, Default_Alignment: TextAlignment.Left, Cells: new string[] { "", "" });
			//Extensions.AddRow(Table: out BasicDetails.Table, RowGroupIndex: 0, Default_Alignment: TextAlignment.Left, Cells: new string[] { "", "" });

			Extensions.AddRow(ref Table1, 0, TextAlignment.Left, "Name", SelectedContact.Name);
			Extensions.AddRow(ref Table1, 0, TextAlignment.Left, "Address", SelectedContact.Address);
			Extensions.AddRow(ref Table1, 0, TextAlignment.Left, "City", SelectedContact.City);
			Extensions.AddRow(ref Table1, 0, TextAlignment.Left, "State", SelectedContact.State);
			Extensions.AddRow(ref Table1, 0, TextAlignment.Left, "Zip", SelectedContact.Zip);

			var PersonalDetails = new Aaron.Reports.Sections.Table("Personal Details", TextAlignment.Left, "", "", new TableColumn { Tag = "Key" }, new TableColumn { Tag = "Value" });
			var Table2 = PersonalDetails.Table;
			Report.Sections.Add(BasicDetails);

			foreach (var item in SelectedContact.PersonalDetails.OrderBy(x => x.Title)) {
				Extensions.AddRow(ref Table2, 0, TextAlignment.Left, item.Title, item.Details);
			}

			Report.Show();
		}

		private void btnDeleteContact_Click(object sender, RoutedEventArgs e) {
			var SelectedContact = dgdContacts.SelectedItem as Database.Contact;
			SelectedContact.IsHidden = true;
			ContactList.Remove(SelectedContact);
			//dgdContacts.DataContext = db.Contacts.Where(x => !x.IsHidden).ToList();
		}

		private void btnAddContact_Click(object sender, RoutedEventArgs e) {
			var NewContact = new Database.Contact();
			db.Contacts.Add(NewContact);
			ContactList.Add(NewContact);
		}
	}
}
