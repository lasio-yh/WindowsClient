using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using ShellApp.Constants;
using System.Windows.Controls;

namespace ShellApp.Views
{
    /// <summary>
    /// ListView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ListPage : UserControl, IContent
    {
        public ListPage()
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
