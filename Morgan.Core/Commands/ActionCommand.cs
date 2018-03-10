using System;
using System.Windows.Input;

namespace Morgan.Core
{
    /// <summary>
    /// A command that can always be executed without any parameters
    /// </summary>
    public class ActionCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// The action to run when the command is executed
        /// </summary>
        private Action mAction;

        #endregion

        #region Events

        /// <summary>
        /// Unused
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new Action Command
        /// </summary>
        /// <param name="action">Action to run</param>
        public ActionCommand(Action action)
        {
            mAction = action;
        }

        #endregion

        #region Command Methods

        public bool CanExecute(object parameter)
        {
            // The command can always be invoked
            return true;
        }

        public void Execute(object parameter)
        {
            // Execute the command
            mAction();
        } 

        #endregion
    }
}
