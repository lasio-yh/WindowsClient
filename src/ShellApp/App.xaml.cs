using System;
using System.Windows;
using ShellApp.Constants;

namespace ShellApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
                ToastNotify.Create();
                ToastNotify.ShowInfo("Starting Application.");
            }
            catch (NullReferenceException ex)
            {
                ToastNotify.ShowError(ex.Message);
                ToastNotify.Dispose();
                this.Shutdown();
            }
            catch (Exception ex)
            {
                ToastNotify.ShowError(ex.Message);
                ToastNotify.Dispose();
                this.Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ToastNotify.ShowInfo("Exit Application.");
            ToastNotify.Dispose();
            base.OnExit(e);
        }
    }
}