using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MnStudio.Constants
{
    class LogCommand
    {
        public static ILog logSystem = LogManager.GetLogger(LOGCADEGORI.SYSTEM.ToString());
        public static ILog logApplication = LogManager.GetLogger(LOGCADEGORI.APPLICATION.ToString());
        public static ILog logCommunication = LogManager.GetLogger(LOGCADEGORI.COMMUNICATION.ToString());
        public static ILog logAction = LogManager.GetLogger(LOGCADEGORI.ACTION.ToString());
        public static void WriteSystem(LOGLEVEL level, string message)
        {
            switch (level)
            {
                case LOGLEVEL.DEBUG:
                    logSystem.Debug(message);
                    break;
                case LOGLEVEL.INFO:
                    logSystem.Info(message);
                    break;
                case LOGLEVEL.ERROR:
                    logSystem.Error(message);
                    break;
                case LOGLEVEL.WARN:
                    logSystem.Warn(message);
                    break;
                case LOGLEVEL.FATAL:
                    logSystem.Fatal(message);
                    break;
                default: break;
            }
        }
        public static void WriteApplication(LOGLEVEL level, string message)
        {
            switch (level)
            {
                case LOGLEVEL.DEBUG:
                    logApplication.Debug(message);
                    break;
                case LOGLEVEL.INFO:
                    logApplication.Info(message);
                    break;
                case LOGLEVEL.ERROR:
                    logApplication.Error(message);
                    break;
                case LOGLEVEL.WARN:
                    logApplication.Warn(message);
                    break;
                case LOGLEVEL.FATAL:
                    logApplication.Fatal(message);
                    break;
                default: break;
            }
        }
        public static void WriteCommunication(LOGLEVEL level, string message)
        {
            switch (level)
            {
                case LOGLEVEL.DEBUG:
                    logCommunication.Debug(message);
                    break;
                case LOGLEVEL.INFO:
                    logCommunication.Info(message);
                    break;
                case LOGLEVEL.ERROR:
                    logCommunication.Error(message);
                    break;
                case LOGLEVEL.WARN:
                    logCommunication.Warn(message);
                    break;
                case LOGLEVEL.FATAL:
                    logCommunication.Fatal(message);
                    break;
                default: break;
            }
        }

        public static void WriteAction(LOGLEVEL level, string message)
        {
            switch (level)
            {
                case LOGLEVEL.DEBUG:
                    logAction.Debug(message);
                    break;
                case LOGLEVEL.INFO:
                    logAction.Info(message);
                    break;
                case LOGLEVEL.ERROR:
                    logAction.Error(message);
                    break;
                case LOGLEVEL.WARN:
                    logAction.Warn(message);
                    break;
                case LOGLEVEL.FATAL:
                    logAction.Fatal(message);
                    break;
                default: break;
            }
        }
    }
}
