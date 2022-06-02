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
                ToastService.Create();
                ToastService.ShowInfo("Starting Application.");
            }
            catch (NullReferenceException ex)
            {
                ToastService.ShowError(ex.Message);
                ToastService.Dispose();
                this.Shutdown();
            }
            catch (Exception ex)
            {
                ToastService.ShowError(ex.Message);
                ToastService.Dispose();
                this.Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ToastService.ShowInfo("Exit Application.");
            ToastService.Dispose();
            base.OnExit(e);
        }
    }
}