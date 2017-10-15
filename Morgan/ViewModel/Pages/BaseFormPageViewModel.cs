using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Morgan
{
    /// <summary>
    /// View Model associated with the <see cref="BaseFormPage"/>
    /// </summary>
    public class BaseFormPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of folder locations to scan for music files
        /// </summary>
        public ObservableCollection<string> LocationsList { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to load music files from the specified location
        /// </summary>
        public ICommand LoadFilesCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseFormPageViewModel()
        {
            // Initialize Commands
            LoadFilesCommand = new ActionCommand(LoadFiles);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Loads all the files from the specified directory
        /// </summary>
        private void LoadFiles()
        {
        }

        #endregion
    }
}
