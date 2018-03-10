using System;
using System.Windows.Input;

namespace Morgan.Core
{
    /// <summary>
    /// An action that can be invoked with a parameter that is passed in from a View
    /// </summary>
    public class ActionParameterCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// The action to run when the command is executed
        /// </summary>
        private Action<object> mAction;

        #endregion

        #region Events

        /// <summary>
        /// Unused
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new Action Parameterized Command
        /// </summary>
        /// <param name="action">Action to run</param>
        public ActionParameterCommand(Action<object> action)
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
            mAction(parameter);
        }

        #endregion
    }
}
