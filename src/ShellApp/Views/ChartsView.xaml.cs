using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using ShellApp.Constants;
using System.Windows.Controls;

namespace ShellApp.Views
{
    /// <summary>
    /// Interaction logic for LoremIpsumView.xaml
    /// </summary>
    public partial class ChartsView : UserControl, IContent
    {
        public ChartsView()
        {
            InitializeComponent();
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            ToastNotify.ShowInfo("OnFragmentNavigation");
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            ToastNotify.ShowOk("OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            ToastNotify.ShowError("OnNavigatedTo");
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            ToastNotify.ShowWarn("OnNavigatingFrom");
        }
    }
}
