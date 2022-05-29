using System;
using System.Windows;

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
            }
            catch (NullReferenceException ex)
            {
                this.Shutdown();
            }
            catch (Exception ex)
            {
                this.Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}