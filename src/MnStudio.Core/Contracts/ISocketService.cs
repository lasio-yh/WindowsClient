using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnStudio.Core.Contracts
{
    public interface ISocketService
    {
        void Open(string ip, int port, int size);
        void Close();
        void Send(string data);
    }
}