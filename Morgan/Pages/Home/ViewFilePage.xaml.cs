using Morgan.Core;

namespace Morgan
{
    /// <summary>
    /// Interaction logic for ViewFilePage.xaml
    /// </summary>
    public partial class ViewFilePage : BasePage
    {
        public ViewFilePage()
        {
            InitializeComponent();
            DataContext = DI.Get<ViewFilePageViewModel>();
        }
    }
}
