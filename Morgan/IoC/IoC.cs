using Ninject;

namespace Morgan
{
    /// <summary>
    /// IoC container for the application using NInject
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Kernel of the IoC container
        /// </summary>
        public static IKernel Kernel { get; set; } = new StandardKernel();

        /// <summary>
        /// Takes care of initialization of the IoC container prior to any service being used
        /// </summary>
        static IoC()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the IoC container
        /// </summary>
        public static void Initialize()
        {
            // Binds a single instance of the ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();

            // TODO: This should stay same in the WPF specific project once the core project is added
            // Bind the directory service that interacts with the file system
            Kernel.Bind<IDirectoryService>().To<DirectoryService>();

            // TODO: This should stay same in the WPF specific project once the core project is added
            // Bind the Metadata service that is used to load metadata from music files
            Kernel.Bind<IMetadataService>().To<MetadataService>();

            // Binds single instances of the view models as required;
            // This should remain in WPF Project unless cross application syncing isn't required
            Kernel.Bind<HomePageViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ViewFilePageViewModel>().ToSelf().InSingletonScope();
        }

        /// <summary>
        /// Returns a service pulled out from the IoC container
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class => Kernel.Get<T>();
    }
}
