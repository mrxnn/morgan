namespace Morgan.Core
{
    /// <summary>
    /// Design time view model for the <see cref="SideMenuControl"/>
    /// </summary>
    public class SideMenuControlDesignModel : SideMenuControlViewModel
    {
        /// <summary>
        /// Instance to be bound at design time
        /// </summary>
        public static SideMenuControlDesignModel Instance => new SideMenuControlDesignModel();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuControlDesignModel()
        {
            // Set the home tab selected at design time
            HomeIsSelected = true;
        }
    }
}
