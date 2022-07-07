using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MnStudio.ViewModels;
using System.Net;
using System.Diagnostics;
using System.Configuration;

namespace MnStudio.Constants
{
    class AppController
    {
        public static LoginViewModel Login;
        public static DocumentViewModel Document;
        public static MessageViewModel Message;
        public static VoteViewModel Vote;
        public static DisplayViewModel Display;
        public static ConnectionViewModel Connection;
        public static StatusViewModel Status;
        public static CommonViewModel Common;
        public static AppearanceViewModel Appearance;
        public static string LocalIpAddress;
        public static string LocalMacAddress;

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
                App.Current.Properties["Password"] = ConfigurationManager.AppSettings["Id"];
                App.Current.Properties["Uid"] = ConfigurationManager.AppSettings["Uid"];
                App.Current.Properties["isChecked"] = ConfigurationManager.AppSettings["isChecked"].Equals(Convert.ToInt32(CONFIGCODE.UNCHECKED).ToString()) ? false : true;
                App.Current.Properties["Encoding"] = ConfigurationManager.AppSettings["Encoding"];
                App.Current.Properties["Path"] = ConfigurationManager.AppSettings["Path"];
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
    }
}