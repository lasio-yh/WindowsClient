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
                ToastService.ShowInfo("11111");
                ToastService.ShowWarn("2222");
            }
            catch (NullReferenceException ex)
            {
                ToastService.Dispose();
                this.Shutdown();
            }
            catch (Exception ex)
            {
                ToastService.Dispose();
                this.Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ToastService.Dispose();
            base.OnExit(e);
        }
    }
}