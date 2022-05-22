using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface ILoggerService
    {
        string UserName { get; set; }
        void Create(string processName, string userName);
        void Debug(object obj);
        void Info(string msg);
        void Error(string msg);
        void Warn(string msg);
        void Fatal(string msg);
    }
}
