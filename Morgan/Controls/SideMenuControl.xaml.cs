using Morgan.Core;
using System.Windows.Controls;

namespace Morgan
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        public SideMenuControl()
        {
            InitializeComponent();
            DataContext = IoC.Get<SideMenuControlViewModel>();
        }
    }
}
