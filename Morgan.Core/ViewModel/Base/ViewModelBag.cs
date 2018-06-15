namespace Morgan.Core
{
    /// <summary>
    /// Provides view models for different locations of the UI (when requested)
    /// </summary>
    public static class ViewModelBag
    {
        /// <summary>
        /// Instance of the application view model that is used across the application
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel { get; set; } = DI.ApplicationViewModel;

        /// <summary>
        /// Instance of the popup menu view model that is used across the application
        /// </summary>
        public static PopupMenuViewModel PopupMenuViewModel { get; set; } = DI.PopupMenuViewModel;
    }
}
