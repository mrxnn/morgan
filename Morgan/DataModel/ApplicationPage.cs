namespace Morgan
{
    public enum ApplicationPage : byte
    {
        // Nothing
        None = 0,

        // Base Home
        // This is not just a page, it is the root page that hosts mutiple pages related to Home tab
        // This was necessary because there are few other pages that can be accessed via Home tab
        BaseHomePage = 1,

        // Settings
        SettingsPage = 2,
    }
}
