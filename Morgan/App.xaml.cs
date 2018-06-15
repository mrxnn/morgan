using Microsoft.Extensions.DependencyInjection;
using Morgan.Core;
using System.Windows;

namespace Morgan
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This method is called when the application is first loaded.
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let the base do whatever it needs.
            base.OnStartup(e);

            // Configure the DI
            ConfigureServices();

            // Show the main window.
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// This method is used to configure the dependencies using dotnetcore built-in DI container!
        /// </summary>
        private void ConfigureServices()
        {
            // Binds a single instance of the PopupMenuViewModel.
            DI.ServiceCollection.AddSingleton<PopupMenuViewModel>();

            // Bind the services that is used via DI.
            DI.ServiceCollection.AddTransient<IDirectoryService, MSWindowsDirectoryService>();

            // *Binds single instances of the view models as required;
            // This should remain in WPF Project unless cross application syncing isn't required;
            DI.ServiceCollection.AddSingleton<HomePageViewModel>();
            DI.ServiceCollection.AddSingleton<ViewFilePageViewModel>();
            DI.ServiceCollection.AddSingleton<SideMenuControlViewModel>();

            // Build the Kernel
            DI.BuildProvider();
        }
    }
}
