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

			#region CefSharp.CefSettings
			{ // <= this forces scoping for 0 pollution :D
				CefSharp.CefSettings settings = new CefSharp.CefSettings();

				if (!System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() + @"\CefSharp_Cache")) {
					System.IO.Directory.Create(System.IO.Directory.GetCurrentDirectory() + @"\CefSharp_Cache");
				}

				settings.CachePath = System.IO.Directory.GetCurrentDirectory() + @"\CefSharp_Cache";



				CefSharp.Cef.Initialize(settings);
			}
			#endregion

			this.DispatcherUnhandledException += App_DispatcherUnhandledException;
		}

		void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
			MessageBox.Show(e.ToString(), e.GetType().FullName, MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}
