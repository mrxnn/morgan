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

            // Bind the directory service that interacts with the file system
            Kernel.Bind<IDirectoryService>().To<DirectoryService>();
        }

        /// <summary>
        /// Returns a service pulled out from the IoC container
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class => Kernel.Get<T>();
    }
}
