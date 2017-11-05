using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Morgan
{
    /// <summary>
    /// Base type of all the view models that centralizes common view model functionality
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Property Changed Members

        /// <summary>
        /// Fired when any property of this type is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Calls to this method will raise the <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName">Name of the property that was changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Call this method to fire up property changed notifications for several properties at once
        /// </summary>
        /// <param name="list">List of property names that was changed</param>
        protected virtual void OnGroupOfPropertyChanged(params string[] list)
        {
            // Just a reminder
            if (list.Count() == 0) throw null;

            list.ToList().ForEach(OnPropertyChanged);
        }

        #endregion
    }
}
