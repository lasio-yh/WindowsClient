using Core.Contracts;
using Newtonsoft.Json;

namespace Core.Services
{
    public class LoggerService : ILoggerService
    {
        private log4net.ILog _log { get; set; }
        private string _userName = string.Empty;
        public string UserName
        {
            get => _userName;
            set => _userName = string.IsNullOrEmpty(value) ? string.Empty : value;
        }

        public void Create(string processName, string userName)
        {
            _log = log4net.LogManager.GetLogger(processName);
            _userName = userName;
        }

        public void Debug(object obj)
        {
            if (!_log.IsDebugEnabled) return;
            var data = JsonConvert.SerializeObject(obj);
            var result = string.Format("{0}|DEBUG|{1}", data);
            _log.Debug(result);
        }

        public void Info(string msg)
        {
            if (!_log.IsInfoEnabled) return;
            var result = string.Format("{0}|INFO|{1}", _userName, msg);
            _log.Info(result);
        }

        public void Error(string msg)
        {
            if (!_log.IsErrorEnabled) return;
            var result = string.Format("{0}|ERROR|{1}", _userName, msg);
            _log.Error(result);
        }

        public void Warn(string msg)
        {
            if (!_log.IsWarnEnabled) return;
            var result = string.Format("{0}|WARN|{1}", _userName, msg);
            _log.Warn(result);
        }

        public void Fatal(string msg)
        {
            if (!_log.IsFatalEnabled) return;
            var result = string.Format("{0}|FATAL|{1}", _userName, msg);
            _log.Fatal(result);
        }
    }
}
