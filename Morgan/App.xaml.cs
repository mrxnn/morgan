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

            // Setup the main application.
            SetupTheApplication();

            // Show the main window.
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Setup the main application
        /// </summary>
        private void SetupTheApplication()
        {
            // Binds a single instance of the PopupMenuViewModel.
            IoC.ServiceCollection.AddSingleton<PopupMenuViewModel>();

            // Bind the services that is used via DI.
            IoC.ServiceCollection.AddTransient<IDirectoryService, DirectoryService>();

            // *Binds single instances of the view models as required;
            // This should remain in WPF Project unless cross application syncing isn't required;
            IoC.ServiceCollection.AddSingleton<HomePageViewModel>();
            IoC.ServiceCollection.AddSingleton<ViewFilePageViewModel>();
            IoC.ServiceCollection.AddSingleton<SideMenuControlViewModel>();

            // Build the Kernel
            IoC.BuildProvider();
        }
    }
}
