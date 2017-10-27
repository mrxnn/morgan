using System.Windows;
using System.Windows.Input;

namespace Morgan
{
    /// <summary>
    /// View Model for handling the main window state
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window that is associated with this view model
        /// </summary>
        private Window _window;

        #endregion

        #region Public Properties

        /// <summary>
        /// Thickness of the area that is displayed the resize forced cursor to resize the Window
        /// </summary>
        public Thickness ResizeBorderThickness => _window.WindowState == WindowState.Maximized ? new Thickness(0) : new Thickness(15);

        /// <summary>
        /// Padding of the border that is used to display the drop shadow area
        /// </summary>
        public Thickness OuterBorderPaddingThickness => _window.WindowState == WindowState.Maximized ? new Thickness(0) : new Thickness(10);

        /// <summary>
        /// The Window Corner Radius (Rounded Corners of the Main Window)
        /// </summary>
        public CornerRadius WindowCornerRadius => _window.WindowState == WindowState.Maximized ? new CornerRadius(0) : new CornerRadius(5);

        /// <summary>
        /// Corner Radius of the Window Title Bar
        /// </summary>
        public CornerRadius TitleBarCornerRadius => _window.WindowState == WindowState.Maximized ? new CornerRadius(1) : new CornerRadius(4);

        #endregion

        #region Commands 

        /// <summary>
        /// Command to minimize the Window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command to maximize the Window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Command to close the Window
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }

        /// <summary>
        /// Command to display the system menu
        /// </summary>
        public ICommand SystemMenuCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new Window View Model
        /// </summary>
        /// <param name="window">The window itself</param>
        public WindowViewModel(Window window)
        {
            _window = window;

            // Initialize Commands
            MinimizeCommand = new ActionCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new ActionCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseWindowCommand = new ActionCommand(() => _window.Close());
            SystemMenuCommand = new ActionCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

            // Fix the Window Resize Issue
            var _resizer = new WindowResizer(_window);

            // Listen out for Window events
            _window.StateChanged += (ss, ee) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterBorderPaddingThickness));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(TitleBarCornerRadius));
            };
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(_window);

            // If the window is maximized, show the menu at 5,5 coordinates
            if (_window.WindowState == WindowState.Maximized)
                return new Point(5,5);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        #endregion
    }
}
