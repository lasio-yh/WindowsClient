using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnStudio.ViewModels;
using System.Net;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using FirstFloor.ModernUI.Presentation;

namespace MnStudio.Constants
{
    class AppController
    {
        public static LoginViewModel Login { get; set; }
        public static DocumentViewModel Document { get; set; }
        public static MessageViewModel Message { get; set; }
        public static VoteViewModel Vote { get; set; }
        public static DisplayViewModel Display { get; set; }
        public static ConnectionViewModel Connection { get; set; }
        public static StatusViewModel Status { get; set; }
        public static CommonViewModel Common { get; set; }
        public static AppearanceViewModel Appearance { get; set; }
        public static EditorViewModel Editor { get; set; }
        public static string LocalIpAddress { get; set; }
        public static string LocalMacAddress { get; set; }
        public static bool StartReceive { get; set; }
        public static bool UsedLogin { get; set; }
        public static bool UsedMiddleWare { get; set; }

        public static void Create()
        {
            try
            {
                Login = new LoginViewModel();
                Document = new DocumentViewModel();
                Message = new MessageViewModel();
                Vote = new VoteViewModel();
                Display = new DisplayViewModel();
                Connection = new ConnectionViewModel();
                Status = new StatusViewModel();
                Common = new CommonViewModel();
                Appearance = new AppearanceViewModel();
                Editor = new EditorViewModel();
                UsedMiddleWare = true;
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        public static void LoadLocalIpAddress()
        {
            try
            {
                var hostIPs = Dns.GetHostAddresses("localhost");
                var localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                LocalMacAddress = localIPs[0].ToString();
                LocalIpAddress = localIPs[1].ToString();
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        public static void LoadConfiguration()
        {
            try
            {
                App.Current.Properties["Id"] = ConfigurationManager.AppSettings["Id"];
                App.Current.Properties["Password"] = ConfigurationManager.AppSettings["Password"];
                App.Current.Properties["Encoding"] = ConfigurationManager.AppSettings["Encoding"];
                App.Current.Properties["Caption"] = ConfigurationManager.AppSettings["Caption"];
                App.Current.Properties["MiddleWareName"] = ConfigurationManager.AppSettings["MiddleWareName"];
                App.Current.Properties["MiddleWarePath"] = ConfigurationManager.AppSettings["MiddleWarePath"];
                App.Current.Properties["MiddleWareUri"] = ConfigurationManager.AppSettings["MiddleWareUri"];
                App.Current.Properties["ServerIp"] = ConfigurationManager.AppSettings["ServerIp"];
                App.Current.Properties["ServerPort"] = ConfigurationManager.AppSettings["ServerPort"];
                App.Current.Properties["FileName"] = ConfigurationManager.AppSettings["FileName"];
                App.Current.Properties["FilePath"] = ConfigurationManager.AppSettings["FilePath"];
                App.Current.Properties["FindDate"] = ConfigurationManager.AppSettings["FindDate"];
                App.Current.Properties["FindSize"] = ConfigurationManager.AppSettings["FindSize"];
                App.Current.Properties["ChannelKey"] = ConfigurationManager.AppSettings["ChannelKey"];
                App.Current.Properties["ProgramKey"] = ConfigurationManager.AppSettings["ProgramKey"];
                App.Current.Properties["BoardSize"] = ConfigurationManager.AppSettings["BoardSize"];
                App.Current.Properties["DetectTime"] = ConfigurationManager.AppSettings["DetectTime"];
                App.Current.Properties["TypeWriteDelay"] = ConfigurationManager.AppSettings["TypeWriteDelay"];
                App.Current.Properties["CrawSpeed"] = ConfigurationManager.AppSettings["CrawSpeed"];
                App.Current.Properties["CrawMargin"] = ConfigurationManager.AppSettings["CrawMargin"];
                App.Current.Properties["CrawWidth"] = ConfigurationManager.AppSettings["CrawWidth"];
                App.Current.Properties["CrawIsShow"] = ConfigurationManager.AppSettings["CrawIsShow"];
                App.Current.Properties["TickerSpeed"] = ConfigurationManager.AppSettings["TickerSpeed"];
                App.Current.Properties["TickerLineSpeed"] = ConfigurationManager.AppSettings["TickerLineSpeed"];
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        public static void SaveConfiguration()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("Id");
                config.AppSettings.Settings.Remove("Password");
                config.AppSettings.Settings.Remove("Encoding");
                config.AppSettings.Settings.Remove("Caption");
                config.AppSettings.Settings.Remove("MiddleWareName");
                config.AppSettings.Settings.Remove("MiddleWarePath");
                config.AppSettings.Settings.Remove("MiddleWareUri");
                config.AppSettings.Settings.Remove("ServerIp");
                config.AppSettings.Settings.Remove("ServerPort");
                config.AppSettings.Settings.Remove("FileName");
                config.AppSettings.Settings.Remove("FilePath");
                config.AppSettings.Settings.Remove("FindDate");
                config.AppSettings.Settings.Remove("FindSize");
                config.AppSettings.Settings.Remove("ChannelKey");
                config.AppSettings.Settings.Remove("ProgramKey");
                config.AppSettings.Settings.Remove("BoardSize");
                config.AppSettings.Settings.Remove("DetectTime");
                config.AppSettings.Settings.Remove("TypeWriteDelay");
                config.AppSettings.Settings.Remove("CrawSpeed");
                config.AppSettings.Settings.Remove("CrawMargin");
                config.AppSettings.Settings.Remove("CrawWidth");
                config.AppSettings.Settings.Remove("CrawIsShow");
                config.AppSettings.Settings.Remove("TickerSpeed");
                config.AppSettings.Settings.Remove("TickerLineSpeed");
                config.AppSettings.Settings.Add("Id", App.Current.Properties["Id"].ToString());
                config.AppSettings.Settings.Add("Password", App.Current.Properties["Password"].ToString());
                config.AppSettings.Settings.Add("Encoding", App.Current.Properties["Encoding"].ToString());
                config.AppSettings.Settings.Add("Caption", App.Current.Properties["Caption"].ToString());
                config.AppSettings.Settings.Add("MiddleWareName", App.Current.Properties["MiddleWareName"].ToString());
                config.AppSettings.Settings.Add("MiddleWarePath", App.Current.Properties["MiddleWarePath"].ToString());
                config.AppSettings.Settings.Add("MiddleWareUri", App.Current.Properties["MiddleWareUri"].ToString());
                config.AppSettings.Settings.Add("ServerIp", App.Current.Properties["ServerIp"].ToString());
                config.AppSettings.Settings.Add("ServerPort", App.Current.Properties["ServerPort"].ToString());
                config.AppSettings.Settings.Add("FileName", App.Current.Properties["FileName"].ToString());
                config.AppSettings.Settings.Add("FilePath", App.Current.Properties["FilePath"].ToString());
                config.AppSettings.Settings.Add("FindDate", App.Current.Properties["FindDate"].ToString());
                config.AppSettings.Settings.Add("FindSize", App.Current.Properties["FindSize"].ToString());
                config.AppSettings.Settings.Add("ChannelKey", App.Current.Properties["ChannelKey"].ToString());
                config.AppSettings.Settings.Add("ProgramKey", App.Current.Properties["ProgramKey"].ToString());
                config.AppSettings.Settings.Add("BoardSize", App.Current.Properties["BoardSize"].ToString());
                config.AppSettings.Settings.Add("DetectTime", App.Current.Properties["DetectTime"].ToString());
                config.AppSettings.Settings.Add("TypeWriteDelay", App.Current.Properties["TypeWriteDelay"].ToString());
                config.AppSettings.Settings.Add("CrawSpeed", App.Current.Properties["CrawSpeed"].ToString());
                config.AppSettings.Settings.Add("CrawMargin", App.Current.Properties["CrawMargin"].ToString());
                config.AppSettings.Settings.Add("CrawWidth", App.Current.Properties["CrawWidth"].ToString());
                config.AppSettings.Settings.Add("CrawIsShow", App.Current.Properties["CrawIsShow"].ToString());
                config.AppSettings.Settings.Add("TickerSpeed", App.Current.Properties["TickerSpeed"].ToString());
                config.AppSettings.Settings.Add("TickerLineSpeed", App.Current.Properties["TickerLineSpeed"].ToString());
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
            }
        }

        public static void IsCheckedMiddleWare()
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    while (AppController.UsedMiddleWare)
                    {
                        Status.IsConnectMiddleWare = ProcessController.IsWatcher();
                        Thread.Sleep(Convert.ToInt32(App.Current.Properties["DetectTime"]));
                    }
                });
            }
            catch (AccessViolationException ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                AppController.UsedMiddleWare = false;
            }
            catch (Exception ex)
            {
                LogCommand.WriteSystem(LOGLEVEL.ERROR, ex.Message);
                AppController.UsedMiddleWare = false;
            }
        }
    }
}