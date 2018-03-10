namespace Morgan.Core
{
    /// <summary>
    /// Design time data for <see cref="PopupMenuControl"/>
    /// </summary>
    public class PopupMenuDesignModel : PopupMenuViewModel
    {
        /// <summary>
        /// Instance to bind at design time
        /// </summary>
        public static PopupMenuDesignModel Instance => new PopupMenuDesignModel();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PopupMenuDesignModel()
        {
            PrimaryMessage = "Hey dude! You're still at design time...";
            SecondaryMessage = "the secondary message doesn't need to be mind blowing";
            ButtonText = "All done!";
        }
    }
}
