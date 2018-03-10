using Ninject;

namespace Morgan.Core
{
    /// <summary>
    /// IoC container for the application using NInject
    /// </summary>
    public static class IoC
    {
        #region Public Property
        
        /// <summary>
        /// Kernel of the IoC container
        /// </summary>
        public static IKernel Kernel { get; set; } = new StandardKernel();

        #endregion

        #region Shorthands

        /// <summary>
        /// Shorthand property to get the <see cref="ApplicationViewModel"/> single instance
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => Kernel.Get<ApplicationViewModel>();

        /// <summary>
        /// Shorthand property to get the <see cref="PopupMenuViewModel"/> single instance
        /// </summary>
        public static PopupMenuViewModel PopupMenuViewModel => Kernel.Get<PopupMenuViewModel>();

        #endregion

        #region Constructors
        
        /// <summary>
        /// Takes care of initialization of the IoC container prior to any service being used
        /// </summary>
        static IoC()
        {
            Initialize();
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Initializes the IoC container
        /// </summary>
        public static void Initialize()
        {
            // Binds a single instance of the ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();

            // Bind a default implementation for a IMetadataService
            Kernel.Bind<IMetadataService>().To<DefaultMetadataService>();

            // Bind a default implementation for a IFileStructureService
            Kernel.Bind<IFileStructureService>().To<DefaultFileStructureService>();
        }

        /// <summary>
        /// Returns a service pulled out from the IoC container
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class => Kernel.Get<T>();

        #endregion
    }
}
