using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using Microsoft.Extensions.Configuration;
using Microsoft.Toolkit.Uwp.Notifications;

using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;

using Windows_Template.Constants;
using Windows_Template.Contracts.Services;
using Windows_Template.Core.Contracts.Services;
using Windows_Template.Core.Services;
using Windows_Template.Models;
using Windows_Template.Services;
using Windows_Template.ViewModels;
using Windows_Template.Views;

namespace Windows_Template
{
    // For more inforation about application lifecyle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview
    // For docs about using Prism in WPF see https://prismlibrary.com/docs/wpf/introduction.html

    // WPF UI elements use language en-US by default.
    // If you need to support other cultures make sure you add converters and review dates and numbers in your UI to ensure everything adapts correctly.
    // Tracking issue for improving this is https://github.com/dotnet/wpf/issues/1946
    public partial class App : PrismApplication
    {
        public const string ToastNotificationActivationArguments = "ToastNotificationActivationArguments";

        private string[] _startUpArgs;

        public App()
        {
        }

        protected override Window CreateShell()
            => Container.Resolve<ShellWindow>();

        protected override async void OnInitialized()
        {
            var persistAndRestoreService = Container.Resolve<IPersistAndRestoreService>();
            persistAndRestoreService.RestoreData();

            var themeSelectorService = Container.Resolve<IThemeSelectorService>();
            themeSelectorService.InitializeTheme();

            // https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop
            ToastNotificationManagerCompat.OnActivated += (toastArgs) =>
            {
                Current.Dispatcher.Invoke(async () =>
                {
                    var config = Container.Resolve<IConfiguration>();

                    // Store ToastNotification arguments in configuration, so you can use them from any point in the app
                    config[App.ToastNotificationActivationArguments] = toastArgs.Argument;

                    App.Current.MainWindow.Show();
                    App.Current.MainWindow.Activate();
                    if (App.Current.MainWindow.WindowState == WindowState.Minimized)
                    {
                        App.Current.MainWindow.WindowState = WindowState.Normal;
                    }

                    await Task.CompletedTask;
                });
            };

            var toastNotificationsService = Container.Resolve<IToastNotificationsService>();
            toastNotificationsService.ShowToastNotificationSample();

            if (ToastNotificationManagerCompat.WasCurrentProcessToastActivated())
            {
                // ToastNotificationActivator code will run after this completes and will show a window if necessary.
                return;
            }

            base.OnInitialized();
            await Task.CompletedTask;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _startUpArgs = e.Args;
            base.OnStartup(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Core Services
            containerRegistry.Register<IFileService, FileService>();

            // App Services
            containerRegistry.RegisterSingleton<IToastNotificationsService, ToastNotificationsService>();
            containerRegistry.Register<IApplicationInfoService, ApplicationInfoService>();
            containerRegistry.Register<IPersistAndRestoreService, PersistAndRestoreService>();
            containerRegistry.Register<IThemeSelectorService, ThemeSelectorService>();
            containerRegistry.Register<ISystemService, SystemService>();
            containerRegistry.Register<ISampleDataService, SampleDataService>();

            // Views
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>(PageKeys.Settings);
            containerRegistry.RegisterForNavigation<WebViewPage, WebViewViewModel>(PageKeys.WebView);
            containerRegistry.RegisterForNavigation<ListDetailsPage, ListDetailsViewModel>(PageKeys.ListDetails);
            containerRegistry.RegisterForNavigation<ContentGridDetailPage, ContentGridDetailViewModel>(PageKeys.ContentGridDetail);
            containerRegistry.RegisterForNavigation<ContentGridPage, ContentGridViewModel>(PageKeys.ContentGrid);
            containerRegistry.RegisterForNavigation<DataGridPage, DataGridViewModel>(PageKeys.DataGrid);
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(PageKeys.Main);
            containerRegistry.RegisterForNavigation<ShellWindow, ShellViewModel>();

            // Configuration
            var configuration = BuildConfiguration();
            var appConfig = configuration
                .GetSection(nameof(AppConfig))
                .Get<AppConfig>();

            // Register configurations to IoC
            containerRegistry.RegisterInstance<IConfiguration>(configuration);
            containerRegistry.RegisterInstance<AppConfig>(appConfig);
        }

        private IConfiguration BuildConfiguration()
        {
            // TODO: Register arguments you want to use on App initialization
            var activationArgs = new Dictionary<string, string>
            {
                { ToastNotificationActivationArguments, string.Empty }
            };

            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return new ConfigurationBuilder()
                .SetBasePath(appLocation)
                .AddJsonFile("appsettings.json")
                .AddCommandLine(_startUpArgs)
                .AddInMemoryCollection(activationArgs)
                .Build();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            var persistAndRestoreService = Container.Resolve<IPersistAndRestoreService>();
            persistAndRestoreService.PersistData();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
        }
    }
}
