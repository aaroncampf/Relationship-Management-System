using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Relationship_Management_System {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {

		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);

			this.DispatcherUnhandledException += App_DispatcherUnhandledException;
		}

		void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
			MessageBox.Show(e.ToString(), e.GetType().FullName, MessageBoxButton.OK, MessageBoxImage.Error);
		}		
	}
}
