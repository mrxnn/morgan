using Morgan.Core;

namespace Morgan
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : BasePage
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = IoC.Get<HomePageViewModel>();
        }
    }
}
