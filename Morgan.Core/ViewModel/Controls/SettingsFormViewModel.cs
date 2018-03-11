using System;
using System.IO;
using System.Windows.Input;

namespace Morgan.Core
{
    /// <summary>
    /// View model for the <see cref="SettingsFormControl"/>
    /// </summary>
    public class SettingsFormViewModel : BaseViewModel
    {
        #region Public Property

        /// <summary>
        /// Controls if the control should be shown
        /// </summary>
        public bool SettingsFormVisible { get; set; }

        /// <summary>
        /// Path to the directory to save the organized files
        /// </summary>
        public string SaveFilePath { get; set; }

        /// <summary>
        /// The file path that is displayed on the control, used for validations
        /// </summary>
        public string DisplaySaveFilePath { get; set; }

        /// <summary>
        /// String containing the structure to build
        /// </summary>
        public string FileStructure { get; set; }

        /// <summary>
        /// The file structure used to to display on the control, used for validations
        /// </summary>
        public string DisplayFileStructure { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to hide or show the settings form control
        /// </summary>
        public ICommand ToggleFormVisibilityCommand { get; set; }

        /// <summary>
        /// Command to save the two required settings and hides the settings control
        /// </summary>
        public ICommand SaveStructureSettingsCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsFormViewModel()
        {
            // Create Commands
            ToggleFormVisibilityCommand = new ActionCommand(ToggleVisibility);
            SaveStructureSettingsCommand = new ActionCommand(SaveStructureSettings);

            // Set the default file location and the structure
            SaveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Structure");
            FileStructure = "genre, artist, album, title";

            // Set the displayed values
            DisplaySaveFilePath = SaveFilePath;
            DisplayFileStructure = FileStructure;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Hides or Show the <see cref="SettingsFormControl"/>
        /// </summary>
        private void ToggleVisibility()
        {
            // Hide the control
            SettingsFormVisible ^= true;

            // Set the displayed values
            DisplaySaveFilePath = SaveFilePath;
            DisplayFileStructure = FileStructure;
        }

        /// <summary>
        /// Save the two required settings and hides the settings control
        /// </summary>
        private void SaveStructureSettings()
        {
            try
            {
                // TODO: Validation - Make sure the entered settings are valid

                // Update the actual values with the displayed values
                SaveFilePath = DisplaySaveFilePath;
                FileStructure = DisplayFileStructure;
            }
            catch (Exception e)
            {
                // TODO: Log the exception to loggers
            }
            finally
            {
                // Hide this control
                SettingsFormVisible ^= true;
            }
        }

        #endregion
    }
}
