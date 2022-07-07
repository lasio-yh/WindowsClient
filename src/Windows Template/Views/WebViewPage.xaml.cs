using System.Windows;
using System.Windows.Controls;

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

using Windows_Template.ViewModels;

namespace Windows_Template.Views
{
    public partial class WebViewPage : UserControl
    {
        private WebViewViewModel ViewModel
            => DataContext as WebViewViewModel;

        public WebViewPage()
        {
            InitializeComponent();
        }

        private void OnNavigationCompleted(object sender, WebViewControlNavigationCompletedEventArgs e)
            => ViewModel.OnNavigationCompleted(e);

        private void WebViewPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel?.Initialize(webView);
        }
    }
}
