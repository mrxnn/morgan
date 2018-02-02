using System;
using System.Windows.Input;

namespace Morgan
{
    /// <summary>
    /// View model for the <see cref="SettingsFormControl"/>
    /// </summary>
    public class SettingsFormViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Controls if the control should be shown
        /// </summary>
        public bool SettingsFormVisible { get; set; }

        /// <summary>
        /// Path to the directory to save the organized files
        /// </summary>
        public string SaveFilePath { get; set; }

        /// <summary>
        /// String containing the structure to build
        /// </summary>
        public string FileStructure { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to hide or show the settings form control
        /// </summary>
        public ICommand ToggleFormVisibilityCommand { get; set; }

        /// <summary>
        /// Command to organize the music files based on the <see cref="FileStructure"/>
        /// </summary>
        public ICommand OrganizeFilesCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsFormViewModel()
        {
            // Create Commands
            ToggleFormVisibilityCommand = new ActionCommand(ToggleVisibility);
            OrganizeFilesCommand = new ActionCommand(OrganizeFiles);

            // Set the default file location and the structure
            SaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            FileStructure = "genre, artist, album, file";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Hides or Show the <see cref="SettingsFormControl"/>
        /// </summary>
        private void ToggleVisibility()
        {
            SettingsFormVisible ^= true;
        }

        /// <summary>
        /// Puts all the files in a logical structure based on the Music tags
        /// </summary>
        private async void OrganizeFiles()
        {
            // TODO:
        }

        #endregion
    }
}
