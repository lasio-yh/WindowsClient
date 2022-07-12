using System;
using System.Collections.Generic;
using System.Windows;
using System.Configuration;
using MnStudio.Constants;
using MnStudio.ViewModels;
using MnStudio.Views;
using MnStudio.Core.Models;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using System.Windows.Controls;
using log4net;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MnStudio
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                LogCommand.WriteApplication(LOGLEVEL.INFO, "어플리케이션이 실행되었습니다.");
                AppController.LoadConfiguration();
                AppController.LoadLocalIpAddress();
                AppController.Create();
                AppController.UsedMiddleWare = true;
                AppController.IsCheckedMiddleWare();
                //ProcessController.StartUp();
                //ServerController.Create();
                base.OnStartup(e);
                Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            }
            catch (NullReferenceException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                ModernDialog.ShowMessage(ex.Message, "Error", MessageBoxButton.OK);
                this.Shutdown();
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                ModernDialog.ShowMessage(ex.Message, "Error", MessageBoxButton.OK);
                this.Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                if (MiddleWareController.Status)
                {
                    ModernDialog.ShowMessage("현재송출중 입니다.", "Info", MessageBoxButton.OK);
                    return;
                }

                if (AppController.StartReceive)
                {
                    ModernDialog.ShowMessage("메시지가 수신중 입니다.", "Info", MessageBoxButton.OK);
                    return;
                }

                if (ServerController.Status)
                {
                    ModernDialog.ShowMessage("서버와 연결중 입니다.", "Info", MessageBoxButton.OK);
                    return;
                }
                AppController.UsedMiddleWare = false;
                LogCommand.WriteApplication(LOGLEVEL.INFO, "어플리케이션이 종료되었습니다.");
                base.OnExit(e);
            }
            catch (NullReferenceException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                ModernDialog.ShowMessage(ex.Message, "Error", MessageBoxButton.OK);
                this.Shutdown();
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                ModernDialog.ShowMessage(ex.Message, "Error", MessageBoxButton.OK);
                this.Shutdown();
            }
        }
    }
}
