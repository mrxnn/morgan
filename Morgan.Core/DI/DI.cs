using Microsoft.Extensions.DependencyInjection;
using System;

namespace Morgan.Core
{
    /// <summary>
    /// IoC container for the application using built-in dotnet core DI
    /// </summary>
    public static class DI
    {
        #region Public Property
        
        /// <summary>
        /// Kernel of the IoC container
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Collection of services that are exposed via DI container
        /// </summary>
        public static IServiceCollection ServiceCollection { get; set; } = new ServiceCollection();

        #endregion

        #region Shorthands

        /// <summary>
        /// Shorthand property to get the <see cref="ApplicationViewModel"/> single instance
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => Get<ApplicationViewModel>();

        /// <summary>
        /// Shorthand property to get the <see cref="PopupMenuViewModel"/> single instance
        /// </summary>
        public static PopupMenuViewModel PopupMenuViewModel => Get<PopupMenuViewModel>();

        #endregion

        #region Constructors
        
        /// <summary>
        /// Takes care of initialization of the IoC container prior to any service being used
        /// </summary>
        static DI()
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
            ServiceCollection.AddSingleton<ApplicationViewModel>();

            // Bind a default implementation for a IMetadataService
            ServiceCollection.AddTransient<IMetadataService, DefaultMetadataService>();

            // Bind a default implementation for a IFileStructureService
            ServiceCollection.AddTransient<IFileStructureService, DefaultFileStructureService>();
        }

        /// <summary>
        /// Builds the Kernel of the IoC container!
        /// </summary>
        public static void BuildProvider() => ServiceProvider = ServiceCollection.BuildServiceProvider();

        /// <summary>
        /// Returns a service pulled out from the IoC container
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class => ServiceProvider.GetService<T>();

        #endregion
    }
}
